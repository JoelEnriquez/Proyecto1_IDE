using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.ObjetosCodigo
{
    [Serializable]
    public class Proyecto
    {
        
        private ArrayList codigoFuentes;

        public Proyecto()
        {
            codigoFuentes = new ArrayList();
        }

        public void agregarCodigoFuente(CodigoFuente codigo)
        {
            codigoFuentes.Add(codigo);
        }

        public void eliminarCodigoFuente()
        {

        }
        
        public ArrayList getCodigoFuentes()
        {
            return codigoFuentes;
        }
    }
}
