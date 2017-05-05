using Chem.DataBase;
using Chem.DataBase.Builder;
using Chem.Managment.Visual.ViewModel;
using Codaxy.Xlio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Chem.Managment.Visual.Migration
{
    public static class ExcelDB
    {
        /// <summary>
        /// Esto migra la base de datos de excel to SqlCe
        /// </summary>
        /// <param name="path"></param>
        /// <param name="viewModel"></param>
        public static void MigrateSubstance(string path, ProgressDialogViewModel viewModel)
        {
            // Get a cancellation token
            var loopOptions = new ParallelOptions();
            loopOptions.CancellationToken = viewModel.TokenSource.Token;

            Workbook workbook = Workbook.Load(path);
            var worksheetSubstance = workbook.Sheets.SingleOrDefault(p => p.SheetName == "Productos Químicos");
            var worksheetEntity = workbook.Sheets.SingleOrDefault(p => p.SheetName == "Entidades");
            // Set the maximum progress value 

            viewModel.ProgressMax = (worksheetEntity.Data.Count + worksheetSubstance.Data.Count);

            // Process work items in parallel
            try
            {
                Parallel.ForEach(worksheetEntity.Data, loopOptions, t => ProcessEntityItem(t,viewModel));
            }
            catch (OperationCanceledException)
            {
                var ShowCancellationMessage = new Action(viewModel.ShowCancellationMessage);
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, ShowCancellationMessage);
            }

            try
            {
                Parallel.ForEach(worksheetSubstance.Data, loopOptions, t => ProcessSubstanceItem(t, viewModel));
            }
            catch (OperationCanceledException)
            {
                var ShowCancellationMessage = new Action(viewModel.ShowCancellationMessage);
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, ShowCancellationMessage);
            }   
        }



        private static void ProcessSubstanceItem(KeyValuePair<int, SheetRow> item1, ProgressDialogViewModel viewModel)
        {
            var substanceRepository = RepoBuilder.CreateSubstanceRepo();
            var synonymRepository = RepoBuilder.CreateSynonymRepo();
            var substance_synonymsRepository = RepoBuilder.CreateSubstance_SynonymRepo();
            var substance_guideRepository = RepoBuilder.CreateSubstance_GuideRepo();
            var guideRepository = RepoBuilder.CreateGuideRepo();
            var entityRepository = RepoBuilder.CreateEntityRepo();
            var substance_entityRepository = RepoBuilder.CreateSubstance_EntityRepo();

            if (item1.Key > 0)
            {
                var idsubstance = substanceRepository.Add(new Substance()
                {
                    Id = substanceRepository.GetId(),
                    ProductName = GetString(item1, 0),
                    FormulaHill = GetString(item1, 2),
                    CAS = GetString(item1, 3),
                    CPCU = GetString(item1, 4),
                    UN = GetString(item1, 5)

                }).Id;
                substanceRepository.SubmitChanges();


                var synonyms = new List<Guid>();
                foreach (var item2 in item1.Value.Cells.Data[1].Value.ToString().Split(';'))
                {
                    substance_synonymsRepository.Add(new Substance_Synonym()
                    {
                        Id = substance_synonymsRepository.GetId(),
                        IdSubstance = idsubstance,
                        IdSynonym = synonymRepository.Add(new Synonym() { Id = synonymRepository.GetId(), Name = item2 }).Id

                    });
                    synonymRepository.SubmitChanges();
                    substance_synonymsRepository.SubmitChanges();
                }


                //Entidad disponible
                foreach (var item in GetString(item1, 6).Split(new string[] { "; " }, StringSplitOptions.None).SkipWhile(p => p == string.Empty))
                {
                    substance_entityRepository.Add(new Substance_Entity()
                    {
                        Id = substance_entityRepository.GetId(),
                        IdSubstance = idsubstance,
                        IdEntity = entityRepository.FindByName(item).Id,
                        Type = 0
                    });
                }


                //Entidad consumidora
                foreach (var item in GetString(item1, 7).Split(new string[] { "; " }, StringSplitOptions.None).SkipWhile(p => p == string.Empty))
                {
                    substance_entityRepository.Add(new Substance_Entity()
                    {
                        Id = substance_entityRepository.GetId(),
                        IdSubstance = idsubstance,
                        IdEntity = entityRepository.FindByName(item).Id,
                        Type = 1
                    });
                }

                //Consultores
                foreach (var item in GetString(item1, 8).Split(new string[] { "; " }, StringSplitOptions.None).SkipWhile(p => p == string.Empty))
                {
                    substance_entityRepository.Add(new Substance_Entity()
                    {
                        Id = substance_entityRepository.GetId(),
                        IdSubstance = idsubstance,
                        IdEntity = entityRepository.FindByName(item).Id,
                        Type = 2
                    });
                }

                substance_entityRepository.SubmitChanges();

                //Guía de gestión
                substance_guideRepository.Add(new Substance_Guide()
                {
                    Id = substance_guideRepository.GetId(),
                    IdSubstance = idsubstance,
                    IdGuide = guideRepository.Add(new Guide()
                    {
                        Id = guideRepository.GetId(),
                        Name = item1.Value.Cells.Data[9].Value.ToString(),
                        Type = 0
                    }).Id
                });

                //Guía de respuesta
                substance_guideRepository.Add(new Substance_Guide()
                {
                    Id = substance_guideRepository.GetId(),
                    IdSubstance = idsubstance,
                    IdGuide = guideRepository.Add(new Guide()
                    {
                        Id = guideRepository.GetId(),
                        Name = item1.Value.Cells.Data[10].Value.ToString(),
                        Type = 1
                    }).Id
                });

                //Guía de seguridad
                substance_guideRepository.Add(new Substance_Guide()
                {
                    Id = substance_guideRepository.GetId(),
                    IdSubstance = idsubstance,
                    IdGuide = guideRepository.Add(new Guide()
                    {
                        Id = guideRepository.GetId(),
                        Name = item1.Value.Cells.Data[11].Value.ToString(),
                        Type = 2
                    }).Id
                });

                //Otra Guía de seguridad
                substance_guideRepository.Add(new Substance_Guide()
                {
                    Id = substance_guideRepository.GetId(),
                    IdSubstance = idsubstance,
                    IdGuide = guideRepository.Add(new Guide()
                    {
                        Id = guideRepository.GetId(),
                        Name = item1.Value.Cells.Data[12].Value.ToString(),
                        Type = 2
                    }).Id
                });


                guideRepository.SubmitChanges();
                substance_guideRepository.SubmitChanges();

                var IncrementProgressCounter = new Action<int>(viewModel.IncrementProgressCounter);
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, IncrementProgressCounter, 1);
        


            }
        }

        private static void ProcessEntityItem(KeyValuePair<int, SheetRow> item1, ProgressDialogViewModel viewModel)
        {
            var entityRepository = RepoBuilder.CreateEntityRepo();
            if (item1.Key > 0)
            {
                entityRepository.Add(new Entity()
                {
                    Id = entityRepository.GetId(),
                    Name = GetString(item1, 0),
                    Address = GetString(item1, 1),
                    Town = GetString(item1, 2),
                    Coord_x = GetString(item1, 3),
                    Coord_y = GetString(item1, 4),
                    Organization = GetString(item1, 5),
                    Phone = GetString(item1, 6),
                    Email = GetString(item1, 7),
                    Fax = GetString(item1, 8)
                });
                entityRepository.SubmitChanges();

                var IncrementProgressCounter = new Action<int>(viewModel.IncrementProgressCounter);
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, IncrementProgressCounter, 1);
        

            }


            
        }

        private static string GetString(KeyValuePair<int, SheetRow> cell, int index)
        {
            if (!cell.Value.Cells.Data.ContainsKey(index))
                return "";
            if (index >= cell.Value.Cells.Data.Count)
                return "";
            if (cell.Value.Cells.Data[index] == null)
                return "";
            if (cell.Value.Cells.Data[index].Value == null)
                return "";
            return cell.Value.Cells.Data[index].Value.ToString();
        }

        private static long GetLong(KeyValuePair<int, SheetRow> cell, int index)
        {
            if (!cell.Value.Cells.Data.ContainsKey(index))
                return 0;
            if (index >= cell.Value.Cells.Data.Count)
                return 0;
            if (cell.Value.Cells.Data[index] == null)
                return 0;
            if (cell.Value.Cells.Data[index].Value == null)
                return 0;
            if (cell.Value.Cells.Data[index].Value.ToString() == string.Empty)
                return 0;
            return long.Parse(cell.Value.Cells.Data[index].Value.ToString());
        }

        private static double GetDouble(KeyValuePair<int, SheetRow> cell, int index)
        {
            if (!cell.Value.Cells.Data.ContainsKey(index))
                return 0;
            if (index >= cell.Value.Cells.Data.Count)
                return 0;
            if (cell.Value.Cells.Data[index] == null)
                return 0;
            if (cell.Value.Cells.Data[index].Value == null)
                return 0;
            if (cell.Value.Cells.Data[index].Value.ToString() == string.Empty)
                return 0;
            return double.Parse(cell.Value.Cells.Data[index].Value.ToString());
        }

    }
}
