using System;
using System.Collections.Generic;
using System.Text;

namespace SampleApp.Core.Projections.Genres
{
    public record GenreEditProjection
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
    }
}
