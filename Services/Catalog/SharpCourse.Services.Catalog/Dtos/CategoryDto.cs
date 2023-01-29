using System;
using MongoDB.Bson;

namespace SharpCourse.Services.Catalog.Dtos
{
	public class CategoryDto
	{
        public CategoryDto()
        {
            this.Id = ObjectId.GenerateNewId().ToString();
        }

        public string Id { get; set; }
        public string Name { get; set; }
    }
}

