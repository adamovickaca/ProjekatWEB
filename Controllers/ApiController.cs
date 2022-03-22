using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors;
using Models;


namespace ProjekatWEB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        public TeretanaContext Context { get; set; }
        public ApiController(TeretanaContext context)
        {
            Context = context;
        }

        [Route("PreuzmiTeretane")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiTeretane()
        {
            try
            {
                var teretane = await Context.Teretane
                .Include(p => p.vrste)
                .ToListAsync();

                return Ok(
                    teretane.Select
                    (p => new
                    {
                        Naziv = p.Naziv,
                        Adresa = p.Adresa,
                        KontaktTelefon = p.KontakTelefon,
                        Email = p.Email,
                        Vrste = p.vrste.Select(q =>
                              new
                              {
                                  Naziv = q.Naziv

                              })
                    }).ToList());
            }



            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("Teretane")]
        [HttpGet]
        public async Task<ActionResult> VratiTeretane()
        {
            try
            {
                return Ok(
                    await Context.Teretane.Include(Teretana => Teretana.vrste).ToListAsync());

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        
        [Route("VratiVrste/{idTeretane}")]
        [HttpGet]
        public async Task<ActionResult> VratiVrste(int idTeretane)
        {
            try
            {
             
                var ret = await Context.Vrste.Where(p => p.teretana.ID == idTeretane).ToListAsync();
                return Ok(ret);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        

        [Route("PreuzmiTreninge/{IdVrste}")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiTreninge(int IdVrste)
        {
            try
            {
                var trening = await Context.Treninzi.Where(p => p.vrsta.ID == IdVrste)
                .Include(p => p.termini)
                .ToListAsync();

                return Ok(
                    trening.Select
                    (p => new
                    {
                        Naziv = p.Naziv,
                        ID=p.ID,
                        Termin = p.termini.Select(q =>
                              new
                              {
                                  Id = q.ID,
                                  Dan = q.Dan,
                                  Vreme = q.Vreme.ToString("HH:mm"),
                                  SlobodnaMesta=q.SlobodnaMesta,
                                  Zauzeto = false,

                              })
                    }).ToList());
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("GetInfo/{IdTreninga}")]
        [HttpGet]
        public async Task<ActionResult> InfoTrening(int IdTreninga)
        {
            try
            {
                var trening = await Context.Treninzi
                    .Where(m => m.ID == IdTreninga)
                    .FirstOrDefaultAsync();

                if (trening == null)
                {
                    return StatusCode(404, "Trening not found.");
                }

                return Ok(trening);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    
        
        [Route("Termini/{idTreninga}/{idTeretane}")]
        [HttpGet]
        public async Task<ActionResult> VratiTermine(int idTreninga, int idTeretane)
        {
            try
            {
             
                var ret = await Context.Termini
                .Where(p => p.trening.ID==idTreninga && p.teretana.ID == idTeretane)
                .Include(p => p.trening)
                .Include(p => p.trener)
                .ToListAsync();
                
                return Ok(ret);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }


        [Route("TerminiTrenera/{email}/{idTeretane}")]
        [HttpGet]
        public async Task<ActionResult> TerminiTrenera(string email, int idTeretane)
        {
            try{

                 var korisnik = await Context.Clanovi.Where(acc => acc.Email == email).FirstOrDefaultAsync();
                 if (korisnik == null)
                return BadRequest("Trener sa unetim korisnickim imenom ne postoji");
            
                var termini=await Context.Termini.Where(p=> p.trener.Email==email && p.teretana.ID==idTeretane)
                        .Include(p=> p.trener)
                        .Include(p=>p.trening)
                        .ToListAsync();
                var termin=termini.Select(p=>
                new{
                    idTermina=p.ID,
                    trener=p.trener.Ime,
                    trening=p.trening.Naziv,
                    Dan=p.Dan,
                    Vreme=p.Vreme.ToString("HH:mm"),
                    SlobodnaMesta=p.SlobodnaMesta,
                    Zauzeto=false,


                });
                return Ok(termin);

            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("VratiTermin/{idTreninga}/{idTeretane}")]
        [HttpGet]
        public async Task<ActionResult> VratiTermin(int idTreninga, int idTeretane)
        {
            try{
                
                var termini=await Context.Termini.Where(p=> p.trening.ID==idTreninga && p.teretana.ID==idTeretane)
                        .Include(p=> p.trener)
                        .Include(p=>p.trening)
                        .ToListAsync();
                var termin=termini.Select(p=>
                new{
                    idTermina=p.ID,
                    trener=p.trener.Ime,
                    trening=p.trening.Naziv,
                    Dan=p.Dan,
                    Vreme=p.Vreme.ToString("HH:mm"),
                    SlobodnaMesta=p.SlobodnaMesta,
                    Zauzeto=false,


                });
                return Ok(termin);

            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
 


        [Route("RegistrujSe/{idTeretane}/{Ime}/{Prezime}/{email}/{lozinka}")]
        [HttpPost]
        public async Task<ActionResult> DodatiKorisnika(int idTeretane, string Ime, string Prezime, string email, string lozinka)
        {
            if(idTeretane < 0)
            {
                return BadRequest("Nema teretane!");
            }


            if (String.IsNullOrEmpty(Ime))
            {
                return BadRequest("Zaboravili ste da uneste ime");
            }
            if (String.IsNullOrEmpty(Prezime))
            {
                return BadRequest("Zaboravili ste da uneste prezime");
            }
            if (String.IsNullOrEmpty(email))
            {
                return BadRequest("Zaboravili ste da uneste email");

            }
   
            if (String.IsNullOrEmpty(lozinka))
            {
                return BadRequest("Zaboravili ste da uneste sifru");
            }
            if (lozinka.Length < 8)
            {
                return BadRequest("Sifra mora imati minimum 8 karaktera");
            }
            var korisnik = await Context.Clanovi
            .Include(t => t.teretana)
            .Where(acc => acc.teretana.ID == idTeretane && acc.Email == email )
            .FirstOrDefaultAsync();

            var teretana=await Context.Teretane.Where(p=>p.ID ==idTeretane).FirstOrDefaultAsync();

            if (korisnik != null)
                return BadRequest("Korisnik sa unetim korisnickim imenom vec postoji");
            try
            {

                Clan c = new Clan
                {
                    Ime = Ime,
                    Prezime = Prezime,
                    Email = email,
                    Lozinka = lozinka,
                    teretana=teretana,

                };
                Context.Clanovi.Add(c);
                await Context.SaveChangesAsync();
                return Ok("Kreiran je novi korisnik");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Route("UlogujSe/{idTeretane}/{email}/{lozinka}/{trener}")]
        [HttpGet]
        public async Task<ActionResult> UlogujSe(int idTeretane,string email, string lozinka, bool trener)
        {

            if (String.IsNullOrEmpty(email))
            {
                return BadRequest("Zaboravili ste da uneste korisnicko ime");
            }
            if (String.IsNullOrEmpty(lozinka))
            {
                return BadRequest("Zaboravili ste da uneste sifru");
            }
            if (lozinka.Length < 8)
            {
                return BadRequest("Sifra mora imati minimum 8 karaktera");
            }

            try
            {
               
                
                var osoba = await Context.Clanovi.Where(acc => acc.Email == email && acc.teretana.ID == idTeretane).FirstOrDefaultAsync();
                
                 if (osoba == null)
                        return BadRequest("Korisnik sa unetim korisnickim imenom ne postoji");

                    if (osoba.Lozinka != lozinka)
                
                        return BadRequest("Uneta je pogresna lozinka");
                    
                    if (osoba.trener != trener)
                      return BadRequest("Unet je pogresan pristup");  

                    return Ok(osoba);



            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
       
        [Route("ZakaziTermin/{idTermina}")]
        [HttpPut]
        public async Task<ActionResult> ZakaziTermin(int idTermina)
        {
             
            try
            {
                    var termin=await Context.Termini.Where(t => t.ID==idTermina).Include(p => p.trening).ThenInclude(s=>s.vrsta).FirstOrDefaultAsync();
                    if (termin!=null){
                        if(termin.trening.vrsta.Naziv=="individualni")
                            {
                                termin.Zauzeto=true;
                               
                                termin.SlobodnaMesta--;
                                
                                return BadRequest("Termin je popunjen!");
                                
                           }
                        else
                        {
                            if(termin.SlobodnaMesta > 0)
                                {
                                    termin.SlobodnaMesta--;
                                }
                                else if(termin.SlobodnaMesta == 0)
                                {
                                    termin.Zauzeto= true;
                                    return BadRequest("Termin je popunjen!");
                                }
                        }

                


                    Context.Termini.Update(termin);

                    await Context.SaveChangesAsync();
                    return Ok($"Uspesno rezervisan trening {termin.trening.Naziv}, u {termin.Dan}, sa pocetkom u {termin.Vreme.ToString("HH:mm")}!");
             
                    }
                    else
                     return BadRequest("Ne postoji trening");

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }





        [Route("IzbrisiTermin/{idTermina}")]
        [HttpDelete]
        public async Task<ActionResult> IzbrisiTrening(int idTermina)
        {
            if (idTermina == 0)
                return BadRequest("Nije odabran termin");
          
            try
            {

                var termin = await Context.Termini.Where(b => b.ID == idTermina).FirstOrDefaultAsync();

                if (termin == null)
                    return BadRequest("Ne postoji termin.");

                

                Context.Termini.Remove(termin);

                await Context.SaveChangesAsync();


                return Ok("Uspesno izbrisan termin!");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Route("IzmeniTermin/{idTermina}/{noviDan}/{novoVreme}")]
        [HttpPut]


        public async Task<ActionResult> IzmeniTermin(int idTermina, string noviDan, string novoVreme)
        {

            var termin = await Context.Termini.Where(p => p.ID == idTermina).FirstOrDefaultAsync();

          /*  if(termin == null)
            {
                return BadRequest("Ne postoji taj termin");
            }*/
            
    
            termin.Dan = noviDan;
            termin.Vreme=DateTime.ParseExact(novoVreme, "HH:mm", null);

            Context.Termini.Update(termin);
            await Context.SaveChangesAsync();

            return Ok($"Uspesno je promenjen termin!");

        }

        
    }
}











