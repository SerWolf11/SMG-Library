using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDOP.Model;
using LibKo.WAPI;
namespace MDOP.ViewModel
{
    public class CajaViewModel : ViewModelBase
    {
        public CajaViewModel()
        {
            GetAll();
        }

        #region Properties
        /// <summary>
        /// The <see cref="CurrentCaja" /> property's name.
        /// </summary>
        public const string CurrentCajaPropertyName = "CurrentCaja";

        private CajaModel _currentCaja;

        /// <summary>
        /// Sets and gets the CurrentCaja property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public CajaModel CurrentCaja
        {
            get
            {
                return _currentCaja;
            }

            set
            {
                if (_currentCaja == value)
                {
                    return;
                }
                _currentCaja = value;
                RaisePropertyChanged(CurrentCajaPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="ListaCajas" /> property's name.
        /// </summary>
        public const string ListaCajasPropertyName = "ListaCajas";

        private List<CajaModel> _lista=new List<CajaModel>();

        /// <summary>
        /// Sets and gets the ListaCajas property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<CajaModel> ListaCajas
        {
            get
            {
                return _lista;
            }

            set
            {
                if (_lista == value)
                {
                    return;
                }

                _lista = value;
                RaisePropertyChanged(ListaCajasPropertyName);
            }
        }

        #endregion


        #region Metodos Privados

        private void GetAll()
        {
            for (int i = 0; i < 10; i++)
            {
                CajaModel k = new CajaModel();
                k.Activa = false;
                k.Contador = i;
                k.IDFarmacia = i;
                k.IDCaja = i;
                k.NombreCaja = "Hola " + i;
                k.UsuarioCreador = "Chuy";
                k.Estatus = false;

                ListaCajas.Add(k);
            }

            ListaCajas = WAPI.Get<List<CajaModel>>("Caja?IDFarmacia=1");
        }
        #endregion


    }
}
