using System;
using System.Threading;

namespace fabricantevendedor
{
    public class Fabricante
    {
        private int _periodicidad;
        private int _cantidad;
        private Almacen _a;
        private Thread _t;
        private Random _rnd = new Random();

        public Fabricante(Almacen a, int periodicidad, int cantidad)
        {
            this._a = a;
            this._periodicidad = periodicidad;
            this._cantidad = cantidad;
        }

        public void Fabrica()
        {

            this._t = new Thread(() => this._Accion());
            this._t.Start();
        }

        public void Termina()
        {
            _t.Join();
        }

        private void _Accion()
        {
            for (int i = 0; i < this._cantidad; i++)
            {
               Thread.Sleep(_periodicidad);
               _a.Guardar();
            }
        }
    }

}
