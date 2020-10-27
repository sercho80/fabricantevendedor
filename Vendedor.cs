using System;
using System.Threading;

namespace fabricantevendedor
{
    public class Vendedor
    {
        private int _periodicidad;
        private int _cantidad;
        private Almacen _a;
        private Thread _t;
        private Random _rnd = new Random();
        public Vendedor(Almacen a, int periodicidad, int cantidad)
        {
            this._a = a;
            this._cantidad = cantidad;
            this._periodicidad = periodicidad;
        }

        public void Vende()
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
               _a.Sacar();
            }
        }
    }
}