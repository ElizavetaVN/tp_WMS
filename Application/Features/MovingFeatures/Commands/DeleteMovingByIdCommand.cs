using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.MovingFeatures.Commands
{
    public class DeleteMovingByIdCommand : IRequest<Moving>
    {
        public int Id { get; set; }
        public class DeleteMovingByIdCommandHandler : IRequestHandler<DeleteMovingByIdCommand, Moving>
        {
            private readonly IMovingDbContext _context;
            public DeleteMovingByIdCommandHandler(IMovingDbContext context)
            {
                _context = context;
            }
            public async Task<Moving> Handle(DeleteMovingByIdCommand command, CancellationToken cancellationToken)
            {
                var Moving = await _context.Moving.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (Moving == null) return default;
                _context.Moving.Remove(Moving);
                await _context.SaveChangesAsync();
                return Moving;
            }
        }
    }
}
