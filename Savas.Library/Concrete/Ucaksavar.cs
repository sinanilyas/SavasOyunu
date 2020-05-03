using Savas.Library.Abstract;

namespace Savas.Library.Concrete
{
    internal class Ucaksavar : Cisim
    {
        public Ucaksavar(int panelGenisligi)
        {
            Left = (panelGenisligi - Width) / 2;
        }
    }
}
