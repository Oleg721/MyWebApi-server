﻿using Dal.Models;
using DTO;
using Contracts;
using System.Threading.Tasks;

namespace BLL.Contracts
{
    public interface ICurrencyService : ICrud<CriptoCoinValue, int, CriptoCoinDto>
    {

    }
}
