using Chem.DataBase;
using Chem.DataBase.Repository;
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
    class Test 
    {
        public string Name{get; set;}

        public string Synonym { get; set; }

        public string GlobalForm { get; set; }
    }
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class HomeSubstance : Page
    {
        SubstanceController substanceController;
        public HomeSubstance()
        {
            InitializeComponent();
          
            substanceController = new SubstanceController();
            dataGrid.ItemsSource = substanceController.Substances;

            //SearchController
            // Supply the control with the list of sections
            List<string> sections = new List<string> { "Producto Químico", "Formula Global" };
            m_txtTest.SectionsList = sections;
            
            // Choose a style for displaying sections
            m_txtTest.SectionsStyle = SearchTextBox.SectionsStyles.RadioBoxStyle;

            // Add a routine handling the event OnSearch
            m_txtTest.OnSearch += new RoutedEventHandler(m_txtTest_OnSearch);

            m_txtTest.TextChanged += m_txtTest_TextChanged;
        }

        void m_txtTest_TextChanged(object sender, TextChangedEventArgs e)
        {
            var change = e.Changes.First();
            if (change.RemovedLength == 1 && change.Offset == 0)
            {
                substanceController.Reset();
                dataGrid.ItemsSource = substanceController.Substances;
            }

        }

        void m_txtTest_OnSearch(object sender, RoutedEventArgs e)
        {
            SearchEventArgs searchArgs = e as SearchEventArgs;

            //Esto debe mejorarse para que apareza marcado uno por defecto
            string section = "Producto Químico";
            if (searchArgs.Sections.Any())
                section = searchArgs.Sections.First();


            
            substanceController.Filter(searchArgs.Keyword, section);
            dataGrid.ItemsSource = substanceController.Substances;
   
           //m_txtSearchContent.Text = "Keyword: " + searchArgs.Keyword + sections;
        }

        private void ViewDetailsClick(object sender, RoutedEventArgs e)
        {
            var hyperlink = (Hyperlink)e.Source;
            
            var frame = (Frame)Application.Current.MainWindow.FindName("frame");
            frame.Navigate(new Details(hyperlink.NavigateUri.OriginalString));
        }

    }
}
