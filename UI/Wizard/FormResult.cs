using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nekdu.UI.Wizard
{
    public partial class FormResult : Form, IWizard
    {
        public FormResult()
        {
            InitializeComponent();
        }

        private FormBaseWizard formBaseWizard = null;
        public void SetFormBase(FormBaseWizard formBaseWizard)
        {
            this.formBaseWizard = formBaseWizard;
        }
        public void SetStatusButtons()
        {
          //  formBaseWizard.EnableBack(false);
          //  formBaseWizard.EnableNext(false);
        }
    }
}
