using NUnit.Framework;
using Servicio.Core.Business.Interfaces;
using Servicio.Core.Data.BDMantenimiento;

namespace Servicio.Test
{
    public class Tests
    {
        private DataReport _service = new DataReport();

        [SetUp]
        public void Setup()
        {
           
        }

        [Test]  
        public void GetRptProductoMasVendido()
        {
            var reponse = _service.GetRptProductoMasVendido();
            Assert.IsNotNull(reponse);
        }
    }
}