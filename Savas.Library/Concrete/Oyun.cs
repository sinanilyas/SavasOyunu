using System;
using System.Drawing;
using System.Windows.Forms;
using Savas.Library.Enum;
using Savas.Library.Interface;

namespace Savas.Library.Concrete
{
    public class Oyun : IOyun
    {
        #region Alanlar

        private readonly Timer _gecenSureTimer = new Timer { Interval = 1000 };
        private TimeSpan _gecenSure;
        private readonly Panel _ucaksavarPanel;

        #endregion

        #region Olaylar

        public event EventHandler GecenSureDegisti;

        #endregion

        #region Özellikler

        public bool DevamEdiyorMu { get; private set; }

        public TimeSpan GecenSure
        {
            get => _gecenSure;
            private set
            {
                _gecenSure = value;

                GecenSureDegisti?.Invoke(this, EventArgs.Empty);
            }
        }

        #endregion

        #region Metotlar

        public Oyun(Panel ucaksavarPanel)
        {
            _ucaksavarPanel = ucaksavarPanel;
            _gecenSureTimer.Tick += GecenSureTimer_Tick;
        }

        private void GecenSureTimer_Tick(object sender, EventArgs e)
        {
            GecenSure += TimeSpan.FromSeconds(1);
        }

        public void Baslat()
        {
            if (DevamEdiyorMu) return;

            DevamEdiyorMu = true;
            _gecenSureTimer.Start();

            UcaksavarOlustur();
        }

        private void UcaksavarOlustur()
        {
            var ucaksavar = new Ucaksavar(_ucaksavarPanel.Width)
            {
                Image = Image.FromFile(@"Gorseller\Ucaksavar.png")
            };

            _ucaksavarPanel.Controls.Add(ucaksavar);
        }

        private void Bitir()
        {
            if (!DevamEdiyorMu) return;

            DevamEdiyorMu = false;
            _gecenSureTimer.Stop();
        }

        public void AtesEt()
        {
            throw new NotImplementedException();
        }

        public void UcaksavariHareketEttir(Yon yon)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
