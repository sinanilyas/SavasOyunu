using System;
using Savas.Library.Enum;

namespace Savas.Library.Interface
{
    internal interface IOyun
    {
        bool DevamEdiyorMu { get; }
        TimeSpan GecenSure { get; }

        void Baslat();
        void AtesEt();
        void UcaksavariHareketEttir(Yon yon);
    }
}
