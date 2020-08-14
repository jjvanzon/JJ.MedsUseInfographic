using System.Drawing;
using System.Windows.Forms;
using JJ.Framework.VectorGraphics.Enums;
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
            diagram.Position.ScaleModeEnum = ScaleModeEnum.ViewPort;

            _mainElement = new MainElement(diagram.Background) { ViewModel = _mainViewModel };

            diagramControl.Location = new Point(0, 0);
            diagramControl.Diagram = diagram;
        }

        private void PositionControls()
        {
            diagramControl.Size = new Size(Width, Height);

            if (diagramControl.Diagram != null)
            {
                diagramControl.Width = ClientSize.Width;
                diagramControl.Height = ClientSize.Height;
            }

            if (_mainElement != null)
            {
                _mainElement.Position.WidthInPixels = ClientSize.Width;
                _mainElement.Position.HeightInPixels = ClientSize.Height;
            }
        }

        private void MainForm_SizeChanged(object sender, System.EventArgs e) => PositionControls();
    }
}