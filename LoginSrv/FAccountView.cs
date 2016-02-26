using System.Windows.Forms;

namespace FAccountView
{
    public partial class TFrmAccountView : Form
    {
        public TFrmAccountView()
        {
            InitializeComponent();
        }

        // Note: the original parameters are Object Sender, ref char Key
        public void EdFindIdKeyPress(System.Object Sender, System.Windows.Forms.KeyPressEventArgs _e1)
        {
            //int I;
            //if (Key != '\r')
            //{
            //    return;
            //}
            //for (I = 0; I < ListBox1.Items.Count; I ++ )
            //{
            //    //@ Unsupported property or method(A): 'Strings'
            //    if (EdFindId.Text == ListBox1.Items.Strings[I])
            //    {
            //        ListBox1.SelectedIndex = I;
            //    }
            //}
        }

        // Note: the original parameters are Object Sender, ref char Key
        public void EdFindIPKeyPress(System.Object Sender, System.Windows.Forms.KeyPressEventArgs _e1)
        {
            //int I;
            //if (Key != '\r')
            //{
            //    return;
            //}
            //for (I = 0; I < ListBox2.Items.Count; I ++ )
            //{
            //    //@ Unsupported property or method(A): 'Strings'
            //    if (EdFindIP.Text == ListBox2.Items.Strings[I])
            //    {
            //        ListBox2.SelectedIndex = I;
            //    }
            //}
        }
    } // end TFrmAccountView
}

namespace FAccountView.Units
{
    public class FAccountView
    {
        public static TFrmAccountView FrmAccountView = null;
    } // end FAccountView
}