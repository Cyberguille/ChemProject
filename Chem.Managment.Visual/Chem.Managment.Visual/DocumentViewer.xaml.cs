using PdfiumViewer;
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

namespace Chem.Managment.Visual
{
    /// <summary>
    /// Interaction logic for DocumentViewer.xaml
    /// HOSTING WF IN WPF SEE
    /// https://msdn.microsoft.com/library/ms742875(v=vs.100).aspx
    /// https://msdn.microsoft.com/es-es/library/ms750944(v=vs.100).aspx
    /// </summary>
    public partial class DocumentViewer : Page
    {
        public DocumentViewer()
        {
            InitializeComponent();
        }

      public void LoadPDF(string source)
      {
        //webBrowserViewerPdf.Source = new Uri(source);
          (wfh.Child as PdfViewer).Document = PdfDocument.Load(source);
      }
    }
}
