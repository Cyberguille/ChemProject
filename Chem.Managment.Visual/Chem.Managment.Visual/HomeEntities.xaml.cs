using Chem.Managment.Visual.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
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
using UIControls;

namespace Chem.Managment.Visual
{
    /// <summary>
    /// Interaction logic for HomeEntities.xaml
    /// </summary>
    public partial class HomeEntities : Page
    {
        public HomeEntities()
        {
            InitializeComponent();

            entityController = new EntityController();
            dataGrid.ItemsSource = entityController.Entities;

            //SearchController
            // Supply the control with the list of sections
            List<string> sections = new List<string> { "Nombre", "Dirección","Municipio","Organización" };
            searchEntity.SectionsList = sections;

            // Choose a style for displaying sections
            searchEntity.SectionsStyle = SearchTextBox.SectionsStyles.RadioBoxStyle;

            // Add a routine handling the event OnSearch
            searchEntity.OnSearch += new RoutedEventHandler(search_OnSearch);

            searchEntity.TextChanged += search_TextChanged;
        }

        private void search_OnSearch(object sender, RoutedEventArgs e)
        {
            SearchEventArgs searchArgs = e as SearchEventArgs;

            //Esto debe mejorarse para que apareza marcado uno por defecto
            string section = "Nombre";
            if (searchArgs.Sections.Any())
                section = searchArgs.Sections.First();



            entityController.Filter(searchArgs.Keyword, section);
            dataGrid.ItemsSource = entityController.Entities;
   
        }

      public void GetByName(string name)
      {
        entityController.GetByName(name);
        dataGrid.ItemsSource = entityController.Entities;

      }

      private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            var change = e.Changes.First();
            if (change.RemovedLength == 1 && change.Offset == 0)
            {
                entityController.Reset();
                dataGrid.ItemsSource = entityController.Entities;
            }
        }

        public EntityController entityController { get; set; }
    }
}
