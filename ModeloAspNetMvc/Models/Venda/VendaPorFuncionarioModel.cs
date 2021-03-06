﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ModeloAspNetMvc.Models.Venda
{
    public class VendaPorFuncionarioModel
    {
        [Display(Name = "De")]
        public string DataInicio { get; set; }

        [Display(Name = "Até")]
        public string DataFim { get; set; }

        [Display(Name = "Funcionário")]
        public string IdFuncionario { get; set; }

        public IEnumerable<SelectListItem> SelectListFuncionarios { get; set; } = new List<SelectListItem>();

        public IEnumerable<ResumoVendaPorFuncionarioModel> ResumoDeVendas { get; set; } = new List<ResumoVendaPorFuncionarioModel>();

    }
}