﻿using MediatR;
using Notes.Application.Interfaces;
using Notes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Commands.CreateNote
{
    public class CreateNoteCommandHandler: IRequestHandler<CreateNoteCommand, Guid>
    {
        private readonly INotesDbContext _context;
        public CreateNoteCommandHandler(INotesDbContext context)
        {
            _context= context;
        }
        public async Task<Guid> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            var note = new Note
            {
                UserId = request.UserId,
                Title = request.Tittle,
                Detail = request.Details,
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                UpdateDate = null
            };
            await _context.Notes.AddAsync(note, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return note.Id;
        }
    }
}
