using Chem.DataBase;
using Chem.DataBase.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chem.Managment.Visual
{
    /// <summary>
    /// Interaction logic for Details.xaml
    /// </summary>
    public partial class Details : Page
    {
        private string _substance;

        public Details()
        {
            InitializeComponent();
        }

        public Details(string substance)
            : this()
        {
            // TODO: Complete member initialization
            this._substance = substance;
            Name.Content = substance;
            InitializeSynonym(substance);
            InitializeSubstance(substance);
            InitializeEntities(substance);
            InitializeGuide(substance);
        }

        private void InitializeGuide(string substance)
        {
            var substance_GuideRepository = new Substance_GuideRepository(new ChemDBEntities());
            var substanceRepo = new SubstanceRepository(new ChemDBEntities());
            Guid substanceId = substanceRepo.FindByName(substance).Id;
            managment.ItemsSource = substance_GuideRepository.GetAll().Where(p => p.IdSubstance == substanceId && p.Guide.Type == 0).Select(p => new { Name = p.Guide.Name }).ToList();
            result.ItemsSource = substance_GuideRepository.GetAll().Where(p => p.IdSubstance == substanceId && p.Guide.Type == 1).Select(p => new { Name = p.Guide.Name }).ToList();
            security.ItemsSource = substance_GuideRepository.GetAll().Where(p => p.IdSubstance == substanceId && p.Guide.Type == 2).Select(p => new { Name = p.Guide.Name }).ToList();
        }

        private string GetType(byte? type)
        {
            if (type == 0)
                return "Guía de Gestión";
            else if (type == 1)
                return "Guía de Respuesta";
            else
                return "Guía de Seguridad";
        }

        private void InitializeEntities(string substance)
        {
            var substance_EntityRepository = new Substance_EntityRepository(new ChemDBEntities());
            var substanceRepo = new SubstanceRepository(new ChemDBEntities());
            Guid substanceId = substanceRepo.FindByName(substance).Id;
            var x = substance_EntityRepository.GetAll().Where(p => p.IdSubstance == substanceId && p.Type == 0).Select(p => new { Name = p.Entity.Name }).ToList();
            available.ItemsSource = substance_EntityRepository.GetAll().Where(p => p.IdSubstance == substanceId && p.Type == 0).Select(p => new { Name = p.Entity.Name }).ToList();
            custumer.ItemsSource = substance_EntityRepository.GetAll().Where(p => p.IdSubstance == substanceId && p.Type == 1).Select(p => new { Name = p.Entity.Name }).ToList();
            Consult.ItemsSource = substance_EntityRepository.GetAll().Where(p => p.IdSubstance == substanceId && p.Type == 2).Select(p => new { Name = p.Entity.Name }).ToList();
        }

        private void InitializeSubstance(string substance)
        {
            var substanceRepo = new SubstanceRepository(new ChemDBEntities());

            substanceProperties.ItemsSource = substanceRepo.GetAll().Where(p => p.ProductName == substance).Select(p => new { FormulaHill = p.FormulaHill, CAS = p.CAS, CPCU = p.CPCU, UN = p.UN }).ToList();
        }

        private void InitializeSynonym(string substance)
        {
            var substance_SynonymRepository = new Substance_SynonymRepository(new ChemDBEntities());
            var substanceRepo = new SubstanceRepository(new ChemDBEntities());
            Guid substanceId = substanceRepo.FindByName(substance).Id;
            var x = substance_SynonymRepository.GetAll().Where(p => p.IdSubstance == substanceId).Select(p => new { Name = p.Synonym.Name }).ToList();
            synonym.ItemsSource = substance_SynonymRepository.GetAll().Where(p => p.IdSubstance == substanceId).Select(p => new { Name = p.Synonym.Name }).ToList();

        }

        private void ViewEntityClick(object sender, RoutedEventArgs e)
        {
            var hyperlink = (Hyperlink)e.Source;
            var frame = (Frame)Application.Current.MainWindow.FindName("frame");
            var entitypage = ((MainWindow)Application.Current.MainWindow).HomeEntities;
            entitypage.GetByName(hyperlink.NavigateUri.OriginalString);
            frame.Navigate(entitypage);
        }


        private void ViewGuidesClick(object sender, RoutedEventArgs e)
        {
            var hyperlink = (Hyperlink)e.Source;
            var frame = (Frame)Application.Current.MainWindow.FindName("frame");
            var docpage = ((MainWindow)Application.Current.MainWindow).DocumentViewer;
            string guide = hyperlink.NavigateUri.OriginalString + ".pdf";
            string path = GetPath(guide);

            docpage.LoadPDF(path);
            frame.Navigate(docpage);
        }

        private string GetPath(string guide)
        {
            string location = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            if (File.Exists(location + "\\DataBase\\Records\\GRE\\" + guide))
                return location + "\\DataBase\\Records\\GRE\\" + guide;
            else if (File.Exists(location + "\\DataBase\\Records\\MERCK\\" + guide))
                return location + "\\DataBase\\Records\\MERCK\\" + guide;
            else if (File.Exists(location + "\\DataBase\\Records\\WINKLER\\" + guide))
                return location + "\\DataBase\\Records\\WINKLER\\" + guide;
            else
                return location + "\\DataBase\\default.pdf";

        }
    }
}
