using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEntityFrameworkCodeFirst
{

    



    class CalculateurPrixAssuranceMoto : CalculateurPrixAssuranceGenerique
    {
        //public override double CalculPrix(AssuranceContratDto inputs)
        //{

        //    //azduazduiazdha

        //}
    }

    class CalculateurPrixAssuranceGenerique
    {
        IServiceFiscalite _f;
        //public CalculateurPrixAssurance(IServiceFiscalite f)
        //{
        //    _f = f;
        //}
        public double CalculFiscalité(double prixContrat)
        {
            //alorithme plus ou moins complexe
            return prixContrat * 0.05;
        }

        public virtual double CalculPrix(AssuranceContratDto inputs)
        {
            // algorithme de calcul du prix de mo nassurance
           
            //ifse ez  zfelfmze

            // 

            return 0;
        }


    }
}


public class AssuranceContratDto
{

}