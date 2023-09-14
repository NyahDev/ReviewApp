using ReviewApp.Data;
using ReviewApp.Interfaces;
using ReviewApp.Models;
using System.ComponentModel.DataAnnotations;

namespace ReviewApp.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext _context;

        public PokemonRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreatePokemon(int ownerId, int categoryId, Pokemon pokemon)
        {
            var pokemonOwnerEntity = _context.owners.Where(a => a.Id == ownerId).FirstOrDefault();
            var category = _context.Categories.Where(a => a.Id == categoryId).FirstOrDefault();

            var pokemonOwner = new PkOwner()
            {
                Owner = pokemonOwnerEntity,
                Pokemon = pokemon,

            };

            _context.Add(pokemonOwner);

            var pokemonCategory = new PkCategory()
            {
                Category = category,
                Pokemon = pokemon,
            };

            _context.Add(pokemonCategory);

            _context.Add(pokemon);
            return Save();
        }

        public bool DeletePokemon(Pokemon pokemon)
        {
            _context.Remove(pokemon);
            return Save();
        }

        public Pokemon GetPokemon(int id)
        {
            return _context.pokemons.Where(p => p.id == id).FirstOrDefault();
        }

        public Pokemon GetPokemon(string name)
        {
            return _context.pokemons.Where(p => p.Name == name).FirstOrDefault();
        }

        public decimal GetPokemonrating(int pokeid)
        {
            var review = _context.reviews.Where(p => p.Pokemon.id == pokeid);

            if (review.Count() <= 0)
                return 0;
            return ((decimal)review.Sum(r => r.Rating) / review.Count());
        }

        public ICollection<Pokemon> GetPokemons()
        {
            return _context.pokemons.OrderBy(p => p.id).ToList();
        }

        public bool pokemonExists(int pokeid)
        {
            return _context.pokemons.Any(p => p.id == pokeid);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdatePokemon(int ownerId, int categoryId, Pokemon pokemon)
        {
            _context.Update(pokemon);
            return Save();
        }
    }
}
