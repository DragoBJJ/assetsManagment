using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Application.Assets.Commands.CreateAsset;
using Assets.Application.Assets.DTO;
using Assets.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Assets.Application.Assets.Queries.GetAllAssets
{
    public class GetAllAssetsQuery() : IRequest<IEnumerable<AssetDTO>>
    {
     
    }
}
