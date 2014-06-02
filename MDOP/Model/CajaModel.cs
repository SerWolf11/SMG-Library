using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDOP.Model
{
    public class CajaModel: BaseInpc
    {

        #region Propiedades
        /// <summary>
        /// The <see cref="IDCaja" /> property's name.
        /// </summary>
        public const string IDCajaPropertyName = "IDCaja";

        private int _IDCaja = 0;

        /// <summary>
        /// Sets and gets the IDCaja property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int IDCaja
        {
            get
            {
                return _IDCaja;
            }

            set
            {
                if (_IDCaja == value)
                {
                    return;
                }

               
                _IDCaja = value;
              OnPropertyChanged(IDCajaPropertyName);
            }
        }


        /// <summary>
        /// The <see cref="Folio" /> property's name.
        /// </summary>
        public const string FolioPropertyName = "Folio";

        private String _Folio = "";

        /// <summary>
        /// Sets and gets the Folio property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public String Folio
        {
            get
            {
                return _Folio;
            }

            set
            {
                if (_Folio == value)
                {
                    return;
                }
                _Folio = value;
                OnPropertyChanged(FolioPropertyName);
            }
        }


        /// <summary>
        /// The <see cref="Estatus" /> property's name.
        /// </summary>
        public const string EstatusPropertyName = "Estatus";

        private Boolean _Estatus = false;

        /// <summary>
        /// Sets and gets the Estatus property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Boolean Estatus
        {
            get
            {
                return _Estatus;
            }

            set
            {
                if (_Estatus == value)
                {
                    return;
                }

                _Estatus = value;
                OnPropertyChanged(EstatusPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="NombreCaja" /> property's name.
        /// </summary>
        public const string NombreCajaPropertyName = "NombreCaja";

        private String _NombreCaja = "";

        /// <summary>
        /// Sets and gets the NombreCaja property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public String NombreCaja
        {
            get
            {
                return _NombreCaja;
            }

            set
            {
                if (_NombreCaja == value)
                {
                    return;
                }

                 _NombreCaja = value;
                OnPropertyChanged(NombreCajaPropertyName);
            }
        }


        /// <summary>
        /// The <see cref="IDFarmacia" /> property's name.
        /// </summary>
        public const string IDFarmaciaPropertyName = "IDFarmacia";

        private int _IDFarmacia = 0;

        /// <summary>
        /// Sets and gets the IDFarmacia property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int IDFarmacia
        {
            get
            {
                return _IDFarmacia;
            }

            set
            {
                if (_IDFarmacia == value)
                {
                    return;
                }

                _IDFarmacia = value;
                OnPropertyChanged(IDFarmaciaPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="UsuarioCreador" /> property's name.
        /// </summary>
        public const string UsuarioCreadorPropertyName = "UsuarioCreador";

        private String _UsuarioCreador = "";

        /// <summary>
        /// Sets and gets the UsuarioCreador property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public String UsuarioCreador
        {
            get
            {
                return _UsuarioCreador;
            }

            set
            {
                if (_UsuarioCreador == value)
                {
                    return;
                }

                _UsuarioCreador = value;
                OnPropertyChanged(UsuarioCreadorPropertyName);
            }
        }


        /// <summary>
        /// The <see cref="Contador" /> property's name.
        /// </summary>
        public const string ContadorPropertyName = "Contador";

        private int _Contador = 1;

        /// <summary>
        /// Sets and gets the Contador property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int Contador
        {
            get
            {
                return _Contador;
            }

            set
            {
                if (_Contador == value)
                {
                    return;
                }

                _Contador = value;
                OnPropertyChanged(ContadorPropertyName);
            }
        }


        /// <summary>
        /// The <see cref="Activa" /> property's name.
        /// </summary>
        public const string ActivaPropertyName = "Activa";

        private Boolean _Activa = false;

        /// <summary>
        /// Sets and gets the Activa property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Boolean Activa
        {
            get
            {
                return _Activa;
            }

            set
            {
                if (_Activa == value)
                {
                    return;
                }

                _Activa = value;
                OnPropertyChanged(ActivaPropertyName);
            }
        }

        #endregion

    }
}
