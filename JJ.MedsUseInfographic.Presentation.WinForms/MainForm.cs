using System.Drawing;
using System.Windows.Forms;
using JJ.MedsUseInfographic.Presentation.VectorGraphics;
using JJ.MedsUseInfographic.Presentation.ViewModels;
using Diagram = JJ.Framework.VectorGraphics.Models.Elements.Diagram;

namespace JJ.MedsUseInfographic.Presentation.WinForms
{
    public partial class MainForm : Form
    {
        private readonly MainElement _mainElement;
        private readonly MainViewModel _mainViewModel;

        public MainForm()
        {
            InitializeComponent();
      
            var presenter = new MainPresenter();
            _mainViewModel = presenter.Show();

            var diagram = new Diagram();
            _mainElement = new MainElement(diagram.Background) { ViewModel = _mainViewModel };

            diagramControl.Location = new Point(0, 0);
            diagramControl.Diagram = diagram;
        }

        private void PositionControls()
        {
            diagramControl.Size = new Size(Width, Height);

            if (_mainElement != null)
            {
                _mainElement.Position.WidthInPixels = Width;
                _mainElement.Position.HeightInPixels = Height;

                // TODO: Would I delegate these scaling intricacies to the MainElement instead?
                // TODO: Some margin.
                //_mainElement.Position.Width = _mainViewModel.MinutesADayForWidth;
                _mainElement.Position.Height = _mainViewModel.Days.Count;
                // TODO: scaled Top X and Left Y.
            }
        }

    }
}