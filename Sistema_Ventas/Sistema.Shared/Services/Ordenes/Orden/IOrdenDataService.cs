﻿namespace Sistema.Shared.Services.Ordenes.Orden
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Sistema.Shared.Entidades.Ordenes;
    using Sistema.Shared.Entidades.Ordenes.Orden;

    public interface IOrdenDataService
    {
        Task<IEnumerable<OrdenViewModel>> Listar(int limit, DateTime? before = null);

        Task<OrdenViewModel> Mostrar(int id);

        Task<bool> Crear(OrdenCrear model);
    }
}
