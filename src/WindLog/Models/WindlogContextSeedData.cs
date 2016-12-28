using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WindLog.Models
{
    public class WindlogContextSeedData
    {
        private WindlogContext _context;

        public WindlogContextSeedData(WindlogContext context)
        {
            _context = context;
        }

        public async Task SeedData()
        {
            await SeedMaterialTypesData();
            await SeedMaterialsData();
            await SeedSpotsAndSessionsData();
            await SeedSessionsData();
        }


        #region Private Methods       

        private async Task SeedMaterialTypesData()
        {
            if (!_context.MaterialTypes.Any())
            {
                var materialTypes = new List<MaterialType>() {
                    new MaterialType() { Name = "Board", Created = DateTime.Now, Memo = "Windfsurfing boards." },
                    new MaterialType() { Name = "Sail", Created = DateTime.Now, Memo = "Windfsurfing sails." },
                    new MaterialType() { Name = "Mast", Created = DateTime.Now, Memo = "Windfsurfing masts." },
                    new MaterialType() { Name = "Boom", Created = DateTime.Now, Memo = "Windfsurfing booms." }
                };
                foreach (var materialType in materialTypes)
                {
                    _context.MaterialTypes.Add(materialType);
                }
            }
            await _context.SaveChangesAsync();
        }

        private async Task SeedMaterialsData()
        {
            if (!_context.Materials.Any())
            {
                var board = _context.MaterialTypes.FirstOrDefault(x => x.Name == "Board");
                var sail = _context.MaterialTypes.FirstOrDefault(x => x.Name == "Sail");
                var mast = _context.MaterialTypes.FirstOrDefault(x => x.Name == "Mast");
                var boom = _context.MaterialTypes.FirstOrDefault(x => x.Name == "Boom");

                var materials = new List<Material>() {
                new Material() { Name = "Titan", MaterialType = board, Brand = "Naish", Model="Titan", Year =2004, Purchase= new DateTime(2016,4,2), Created = DateTime.Now, Memo = "Naish Titan comprada en Marbella." },
                new Material() { Name = "Rocket95", MaterialType = board, Brand = "Tabou", Model="Rocket 95", Year =2010, Purchase= new DateTime(2016,5,27), Created = DateTime.Now, Memo = "Comprada a SpinOut Tarifa." },
                new Material() { Name = "RRDQuad", MaterialType = board, Brand = "RRD", Model="WabeCult LTD 83", Year =2014, Purchase= new DateTime(2016,9,5), Created = DateTime.Now, Memo = "Comprada a Ozu Tarifa." },
                new Material() { Name = "NaishWave", MaterialType = board, Brand = "Mistral", Model="Naish 8.5", Year =2000, Purchase= new DateTime(2016,4,30), Created = DateTime.Now, Memo = "Regalada por Luisli." },
                new Material() { Name = "HotSails42", MaterialType = sail, Brand = "Hot Sails", Model="Legend 4.2", Year =2008, Purchase= new DateTime(2016,2,25), Created = DateTime.Now, Memo = "Comprada por facebook en Valencia." },
                new Material() { Name = "GaMa47", MaterialType = sail, Brand = "Gaastra", Model="Manic 4.7", Year =2006, Purchase= new DateTime(2016,5,9), Created = DateTime.Now, Memo = "Comprada por totalwind." },
                new Material() { Name = "P7Slash52", MaterialType = sail, Brand = "Point7", Model="Slash 5.2", Year =2014, Purchase= new DateTime(2016,4,15), Created = DateTime.Now, Memo = "Comprada a Manu." },
                new Material() { Name = "P7Sado59", MaterialType = sail, Brand = "Point7", Model="Sado 5.9", Year =2014, Purchase= new DateTime(2016,4,15), Created = DateTime.Now, Memo = "Comprada a Manu." },
                new Material() { Name = "GaCr64", MaterialType = sail, Brand = "Gaastra", Model="Cross 6.4", Year =2014, Purchase= new DateTime(2016,6,20), Created = DateTime.Now, Memo = "Comprada por mil anuncios a Pepe." },
                new Material() { Name = "N370SDM", MaterialType = mast, Brand = "North Sails", Model="Drop Shape 370 100%", Year =2008, Purchase= new DateTime(2016,2,25), Created = DateTime.Now, Memo = "Comprado por facebook" },
                new Material() { Name = "P400RDM", MaterialType = mast, Brand = "Point7", Model="400 60%", Year =2015, Purchase= new DateTime(2016,4,15), Created = DateTime.Now, Memo = "Comprado a Manu." },
                new Material() { Name = "G430RDM", MaterialType = mast, Brand = "Gun Sails", Model="Cross 430 50%", Year =2016, Purchase= new DateTime(2016,6,14), Created = DateTime.Now, Memo = "Comprado en la web de Gun nuevo." },
                new Material() { Name = "B3140", MaterialType = boom, Brand = "B3", Model="130", Year =2016, Purchase= new DateTime(2016,4,16), Created = DateTime.Now, Memo = "Comprada en la web de B3 nueva." },
                new Material() { Name = "B3160", MaterialType = boom, Brand = "B3", Model="160", Year =2016, Purchase= new DateTime(2016,6,14), Created = DateTime.Now, Memo = "Comprada en la web de B3 nueva." }
                };
                foreach (var material in materials)
                {
                    _context.Materials.Add(material);
                }
            }
            await _context.SaveChangesAsync();
        }

        private async Task SeedSpotsAndSessionsData()
        {

            if (!_context.Spots.Any())
            {
                var torre = new Spot() { Name = "Torrenueva", City = "Torrenueva", Province = "Granada", Country = "España", Created = DateTime.Now, Memo = "" };
                var rules = new Spot() { Name = "Rules", City = "", Province = "Granada", Country = "España", Created = DateTime.Now, Memo = "Embalse de Rules." };
                var playaGranada = new Spot() { Name = "PlayaGranada", City = "Motril", Province = "Granada", Country = "España", Created = DateTime.Now, Memo = "" };
                var ponde = new Spot() { Name = "La Ponderosa", City = "Almuñecar", Province = "", Country = "España", Created = DateTime.Now, Memo = "También llamado Las Góndolas." };
                var valde = new Spot() { Name = "Valdevaqueros", City = "Tarifa", Province = "Cádiz", Country = "España", Created = DateTime.Now, Memo = "" };
                var lances = new Spot() { Name = "Los Lances Norte", City = "Tarifa", Province = "Cádiz", Country = "España", Created = DateTime.Now, Memo = "" };
                var victor = new Spot() { Name = "Victor Center(Almerimar)", City = "El Ejido", Province = "Almería", Country = "España", Created = DateTime.Now, Memo = "" };
                var marAzul = new Spot() { Name = "Mar Azul(Almerimar)", City = "El Ejido", Province = "Almería", Country = "España", Created = DateTime.Now, Memo = "" };
                var pinchos = new Spot() { Name = "Los Pinchos(Almerimar)", City = "El Ejido", Province = "Almería", Country = "España", Created = DateTime.Now, Memo = "" };

                _context.Spots.Add(torre);
                _context.Spots.Add(rules);
                _context.Spots.Add(playaGranada);
                _context.Spots.Add(ponde);
                _context.Spots.Add(valde);
                _context.Spots.Add(lances);
                _context.Spots.Add(victor);
                _context.Spots.Add(marAzul);
                _context.Spots.Add(pinchos);

                var sessions = new List<Session>() {
                new Session() { Name = "Rules1", Spot = rules, SessionDate = new DateTime(2016,5,1) },
                new Session() { Name = "TorreNueva1", Spot = torre, SessionDate = new DateTime(2016,5,2) },
                new Session() { Name = "Ponderosa1", Spot = ponde, SessionDate = new DateTime(2016,5,13) },
                new Session() { Name = "PlayaGranada1", Spot = playaGranada, SessionDate = new DateTime(2016,5,20) },
                new Session() { Name = "Rules2", Spot = rules, SessionDate = new DateTime(2016,5,21) },
                new Session() { Name = "Valdevaqueros1", Spot = valde, SessionDate = new DateTime(2016,5,26) },
                new Session() { Name = "Valdevaqueros2", Spot = valde, SessionDate = new DateTime(2016,5,27) },
                new Session() { Name = "Ponderosa2", Spot = ponde, SessionDate = new DateTime(2016,5,29) }
            };

                foreach (var session in sessions)
                {
                    _context.Sessions.Add(session);
                }
                await _context.SaveChangesAsync();
            }
        }

        private async Task SeedSessionsData()
        {

            if (!_context.SessionMaterials.Any())
            {
                var titan = _context.Materials.FirstOrDefault(x => x.Name == "Titan");
                var rocket = _context.Materials.FirstOrDefault(x => x.Name == "Rocket95");
                var rrdQuad = _context.Materials.FirstOrDefault(x => x.Name == "RRDQuad");
                var hotSails = _context.Materials.FirstOrDefault(x => x.Name == "HotSails42");
                var gaMa = _context.Materials.FirstOrDefault(x => x.Name == "GaMa47");
                var p7Slash = _context.Materials.FirstOrDefault(x => x.Name == "P7Slash52");
                var p7Sado = _context.Materials.FirstOrDefault(x => x.Name == "P7Sado59");
                var gaCr = _context.Materials.FirstOrDefault(x => x.Name == "GaCr64");
                var n370 = _context.Materials.FirstOrDefault(x => x.Name == "N370SDM");
                var p400 = _context.Materials.FirstOrDefault(x => x.Name == "P400RDM");
                var g430 = _context.Materials.FirstOrDefault(x => x.Name == "G430RDM");
                var b3140 = _context.Materials.FirstOrDefault(x => x.Name == "B3140");
                var b3160 = _context.Materials.FirstOrDefault(x => x.Name == "B3160");

                var rules1 = _context.Sessions.FirstOrDefault(x => x.Name == "Rules1");
                var rules2 = _context.Sessions.FirstOrDefault(x => x.Name == "Rules2");
                var torre1 = _context.Sessions.FirstOrDefault(x => x.Name == "Torrenueva1");
                var ponde1 = _context.Sessions.FirstOrDefault(x => x.Name == "Ponderosa1");
                var ponde2 = _context.Sessions.FirstOrDefault(x => x.Name == "Ponderosa2");
                var playaGr1 = _context.Sessions.FirstOrDefault(x => x.Name == "PlayaGranada1");
                var valde1 = _context.Sessions.FirstOrDefault(x => x.Name == "Valdevaqueros1");
                var valde2 = _context.Sessions.FirstOrDefault(x => x.Name == "Valdevaqueros2");

                AddMaterialsToSession(_context, rules1,new Material[] { titan, p7Sado, p400, b3140 });
                AddMaterialsToSession(_context, torre1, new Material[] { titan, p7Sado, p400, b3140 });
                AddMaterialsToSession(_context, ponde1, new Material[] { titan, p7Slash, p400, b3140 });
                AddMaterialsToSession(_context, playaGr1, new Material[] { titan, p7Sado, p400, b3140 });
                AddMaterialsToSession(_context, rules2, new Material[] { titan, p7Sado, p400, b3140 });
                AddMaterialsToSession(_context, valde1, new Material[] { titan, p7Sado, p400, b3140 });
                AddMaterialsToSession(_context, valde2, new Material[] { titan, p7Sado, p400, b3140 });
                AddMaterialsToSession(_context, ponde2, new Material[] { rocket, p7Slash, p400, b3140 });

                await _context.SaveChangesAsync();
            }
        }

        private void AddMaterialsToSession(WindlogContext _context, Session session, Material[] materials)
        {
            foreach (var material in materials)
            {
                _context.SessionMaterials.Add(
                   new SessionMaterials
                   {
                       SessionId = session.Id,
                       Session = session,
                       MaterialId = material.Id,
                       Material = material
                   });
            }
        }
        #endregion
    }
}
