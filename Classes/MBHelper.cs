namespace GBF_Never_Buddy.Classes
{
    internal class MBHelper
    {
        public void ErrorMB(string message, string caption)
        {
            string msg = message;
            string cap = caption;
            MessageBox.Show(message, caption,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
        }
        public void SuccessMB(string message, string caption)
        {
            string msg = message;
            string cap = caption;
            MessageBox.Show(message, caption,
                                MessageBoxButtons.OK
                                );
        }
    }
}
