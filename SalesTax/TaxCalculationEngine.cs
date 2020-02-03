using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax
{
    public class TaxCalculationEngine
    {
        public TaxCalculationEngine()
        {
            
        }
    }
}

/*
  builder.Register<Func<TypeOfDataUpload, ISubmitStrategy>>(c =>
            {
                var cc = c.Resolve<IComponentContext>();
                return (typeOfDataUpload) =>
                {
                    NamedParameter changeIdentifierParameter = GetNamedParameter("changesIdentifierStrategy", typeOfDataUpload, cc);
                    NamedParameter xmlTemplateParameter = GetNamedParameter("xmlTemplateProcessor", typeOfDataUpload, cc);

                    switch (typeOfDataUpload)
                    {
                        case TypeOfDataUpload.DataChange:
                            return cc.Resolve<DataChangeSubmit>(changeIdentifierParameter, xmlTemplateParameter);
                        case TypeOfDataUpload.VariablePayItem:
                            return cc.Resolve<VariablePayItemSubmit>(changeIdentifierParameter);
                        case TypeOfDataUpload.KeyFields:
                            return cc.Resolve<KeyFieldsSubmit>(changeIdentifierParameter);
                        case TypeOfDataUpload.DependentData:
                            return cc.Resolve<DependantDataSubmit>(changeIdentifierParameter);
                        case TypeOfDataUpload.BenefitChange:
                            return cc.Resolve<BenefitChangeSubmit>(changeIdentifierParameter);
                        default:
                            throw new ArgumentException();
                    }
                };
            });
     */
