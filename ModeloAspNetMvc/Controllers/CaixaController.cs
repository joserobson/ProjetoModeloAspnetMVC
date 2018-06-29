﻿using AutoMapper;
using ModeloAspNetMvc.Models.Caixa;
using Project.Layer.App.AppServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModeloAspNetMvc.Controllers
{
    public class CaixaController : Controller
    {
        private ICaixaAppService _caixaAppService;


        public CaixaController(ICaixaAppService caixaAppService)
        {
            this._caixaAppService = caixaAppService;
        }

        // GET: Caixa
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FechamentoDiario()
        {
            var dados = Mapper.Map<IEnumerable<FechamentoDiarioModel>>(_caixaAppService.ObterFechamentos());

            return View(new TelaFechamentoDiarioModel
            {
                Fechamentos = dados,
                FiltroDia = DateTime.Now
            });
        }
    }
}