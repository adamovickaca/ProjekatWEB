import { Termin } from "./Termin.js";
import { Clan } from "./Clan.js";
import { Vrsta } from "./Vrsta.js";
//import {Trening} from "/.Trening.js";

export class Teretana {
    constructor(id, naziv, vrste) {
        this.id = id;
        this.naziv = naziv;
        //this.adresa=adresa;
        this.vrste = vrste;
        /*this.email=email;
        this.kontaktTel=kontaktTel;
        this.listaVrsta=listaVrsta;
        this.listaClanova=null;*/
        this.clan = new Clan(null);
        this.container = null; 

    }

    crtajTeretanu(host) {
        if (!host)
            throw new Error("Host ne postoji!");


        this.container = host;
        var red = document.createElement("div");
        red.innerHTML = this.naziv;
        red.className = "Naziv";
        this.container.appendChild(red);
        let glavniDeo = document.createElement("div");
        glavniDeo.className = "GlavniKontejner"

        this.clan = new Clan(this);

        var red2 = document.createElement("div");
        red2.className = "ClanZaglavlje";
        var labela = document.createElement("label");
        labela.className = "ClanZaglavljeLabela";
        labela.innerHTML = "Uloguj se";
        red2.appendChild(labela);
        labela.onclick = (ev) => this.clan.crtajClanaSkraceno(glavniDeo, this.id);
        
        labela = document.createElement("label");
        labela.className = "ClanZaglavljeLabela";
        labela.innerHTML = "Registruj se";
        red2.appendChild(labela);
        labela.onclick = (ev) => this.clan.crtajClana(glavniDeo, this.id);
        
        labela=document.createElement("label");
        labela.className="ClanZaglavljeLabela";
        labela.innerHTML="Odjavi se";
        red2.appendChild(labela);

        labela.onclick = (ev) =>{ 
            if(this.clan == null)
            {
                alert("Prijavite se ili se registrujte!");
                return;
            }
            this.clan=null;
            window.location.reload();

            alert("Uspesno ste se odjavili!");
            }    

         this.container.appendChild(red2);

        this.container.appendChild(glavniDeo);

        //this.prikaziTreninge(glavniDeo);
        //this.crtajVrstaFormu(glavniDeo);
        //this.crtajTreningFormu(glavniDeo);
        this.crtajTrVrFormu(glavniDeo);
        //this.crtajDugmice(glavniDeo);
        // this.crtajDugmeFormu(glavniDeo);
        //this.crtajKartu(glavniDeo, this.clan);

    }
    crtajTrVrFormu(host)
    {
        let forma = document.createElement("div");
        forma.className = "FormaForma";
        host.appendChild(forma);
        this.crtajVrstaFormu(forma);
        this.crtajTreningFormu(forma);
        //this.pretrazi(forma, clan);

    }

    crtajVrstaFormu(forma) {
        var url = "https://localhost:5001/Api/VratiVrste/" + this.id;
        fetch(url, {
            method: "GET",

            headers: {
                'Content-Type': 'application/json'
            }

        }).then(s => {
            if (s.ok) {

                s.json().then(data => {

                    let vrstaForma = document.createElement("div");
                    vrstaForma.className = "VrstaForma";
                    forma.appendChild(vrstaForma);


                    var red = document.createElement("div");
                    red.className = "VrstaZaglavlje";
                    var labela = document.createElement("label");
                    labela.className="lv";
                    labela.innerHTML = "Vrsta: ";
                    red.appendChild(labela);

                    var se = document.createElement("select");
                    se.className = "comboBox";


                    data.forEach(element => {
                        var op = document.createElement("option");
                        op.innerHTML = element.naziv;
                        op.value = element.id;
                        //console.log(element.naziv);
                        //console.log(element.id);
                        se.appendChild(op);
                    })

                    red.appendChild(se);
                    // vrstaForma.appendChild(red);}


                    var btnPretrazi = document.createElement("button");
                    btnPretrazi.onclick = (ev) => this.crtajTreningFormu(forma);
                    btnPretrazi.innerHTML = "Pretrazi";
                    red.appendChild(btnPretrazi);
                    btnPretrazi.className = "PretraziDugme";

                    vrstaForma.appendChild(red);
                }

                )
            }
        })


    }
    removeTreningFormu(host) {
        var treningForma = host.querySelector(".TreningForma");
        if (treningForma != null) {
            let roditelj = treningForma.parentNode;
            roditelj.removeChild(treningForma);
        }
    }

    crtajTreningFormu(host) {
        let vrsta = host.querySelector(".comboBox");
        if (vrsta == null)
            return;
        //console.log(vrsta.options[vrsta.selectedIndex]);
        let idVrste = vrsta.options[vrsta.selectedIndex].value;
        //console.log(idVrste);


        var url = "https://localhost:5001/Api/PreuzmiTreninge/" + idVrste;
        fetch(url, {
            method: "GET",

            headers: {
                'Content-Type': 'application/json'
            }

        }).then(s => {
            if (s.ok) {

                s.json().then(data => {

                    this.removeTreningFormu(host);

                    let treningForma = document.createElement("div");
                    treningForma.className = "TreningForma";
                    host.appendChild(treningForma);

                    var red = document.createElement("div");
                    red.className = "TreningZaglavlje";
                    var labela = document.createElement("label");
                    labela.className="lv";
                    labela.innerHTML = "Trening: ";
                    red.appendChild(labela);

                    var se = document.createElement("select");
                    se.className = "comboBox1";

                    data.forEach(element => {
                        //this.trening.forEach((p, i) => {
                        var op = document.createElement("option");
                        op.innerHTML = element.naziv;
                        op.value = element.id;
                        se.appendChild(op);
                    })



                    red.appendChild(se);
                    var btnPretrazi = document.createElement("button");
                    btnPretrazi.onclick = (ev) => this.pretrazi(treningForma);
                    btnPretrazi.innerHTML = "Termini";
                    red.appendChild(btnPretrazi);
                    btnPretrazi.className = "PretraziDugme";
                    treningForma.appendChild(red);
                    host.appendChild(treningForma);

                       var btnSaznajVise = document.createElement("button");
                       btnSaznajVise.onclick = (ev) => this.saznaj(treningForma);
                       btnSaznajVise.innerHTML = "Saznaj";
                       red.appendChild(btnSaznajVise);
                       btnSaznajVise.className = "SaznajDugme";
                       treningForma.appendChild(red);

                })
            }
        })

    }

    removeSaznaj(host)
    {
        var saznaj = host.querySelector(".glavni");

        if (saznaj !== null) {
        let rod = saznaj.parentNode;
        rod.removeChild(saznaj);
    }

    }

    saznaj(host)
    {
    let trening = host.querySelector(".comboBox1");
    let idTreninga = trening.options[trening.selectedIndex].value;

    var url = "https://localhost:5001/Api/GetInfo/" + idTreninga;

    fetch(url, {
        method: "GET",

        headers: {
            'Content-Type': 'application/json'
        }

    }).then(s => {
        if (s.ok) {

            s.json().then(data => {

                    //data.forEach(element => {
                        this.removeSaznaj(host);
                        this.removeTabelu(host);

                    let glavni=document.createElement("div");
                    glavni.className="glavni";

                    let div=document.createElement("div");
                    div.className="divTrening";
                    div.classList.add("treningPoster");

                  //  const imgWrapper = document.createElement("div");
                    //imgWrapper.className="imgWrapper";
                    let image=document.createElement("img");
                    image.src=data.slikaPath;
                    image.className="image";
                    //imgWrapper.appendChild(image);
                    div.appendChild(image);
                    glavni.appendChild(div);
                    
                    let ostaleInfo=document.createElement("div");
                    ostaleInfo.className="ostaleInfo";
                    glavni.appendChild(ostaleInfo);
                    let red=document.createElement("div");
                    red.className="nazivTreninga";
                    let ltr=document.createElement("label");
                    ltr.className="l1";
                    ltr.innerHTML="Naziv treninga: ";
                    red.appendChild(ltr);
                    let ln=document.createElement("label");
                    ln.className="l2";
                    ln.innerHTML=data.naziv;
                    red.appendChild(ln);
                    ostaleInfo.appendChild(red);


                    let red1=document.createElement("div");
                    red1.className="opisTreninga";
                    let lt=document.createElement("label");
                    lt.className="l3";
                    lt.innerHTML="Opis treninga: ";
                    red1.appendChild(lt);
                    let l=document.createElement("label");
                    l.className="l4";
                    l.innerHTML=data.opis;
                    red1.appendChild(l);
                    
                    ostaleInfo.appendChild(red1);
                    let red2=document.createElement("div");
                    red2.className="trajanjeTreninga";
                    let ltl=document.createElement("label");
                    ltl.className="l5";
                    ltl.innerHTML="Trajanje treninga: ";
                    red2.appendChild(ltl);
                    let l1=document.createElement("label");
                    l1.className="l4";
                    l1.innerHTML=data.trajanje + "min";
                    red2.appendChild(l1);

                    ostaleInfo.appendChild(red2);

                    glavni.appendChild(ostaleInfo);

                    host.appendChild(glavni);
                    //host.appendChild(ostaleInfo);


               // });

            
            })
        }
    })
}

    removeTabelu(host) {
    var TrenerForma = host.querySelector(".TabelaTermini");

    if (TrenerForma !== null) {
        let rod = TrenerForma.parentNode;
        rod.removeChild(TrenerForma);
    }
}


    


    pretrazi(host,clan) {

        let trening = host.querySelector(".comboBox1");
        let idTreninga = trening.options[trening.selectedIndex].value;
        console.log(idTreninga);

        var url = "https://localhost:5001/Api/VratiTermin/" + idTreninga + "/" + this.id;

        fetch(url, {
            method: "GET",

            headers: {
                'Content-Type': 'application/json'
            }

        }).then(s => {
            if (s.ok) {

                s.json().then(data => {

                    this.removeSaznaj(host);
                    this.removeTabelu(host);
                    var tabela = this.napraviTabelu(host);
                    tabela.className = "TabelaTermini";

                    data.forEach(element => {


                        //console.log(element.idTermina);
                        var p = new Termin(element.idTermina, this.id, this.naziv, element.trening, element.dan, element.vreme, element.trener, element.slobodnaMesta);

                        p.dodajUTabelu(tabela);
                        // this.zakazi(host);

                    });


                    this.zakazi(host, this.clan);

                })
            }
        })
    }
    zakazi(host, clan) {
        var tabela = host.querySelector(".TabelaTermini");//vraca 1.tabelu
        //console.log(tabela);
        var tRow = tabela.querySelectorAll(".tabelRow");//sve redpve
        
        console.log("redovi" + tRow);

        tRow.forEach(red => {
            var btnzakazi=red.querySelector(".btnZakazi");
            btnzakazi.onclick = (ev) => { this.zakaziTermin(red.value, clan)
                //da se nadje dugme
                console.log("vrednost" + red.value);
            }
        })

    }


    zakaziTermin(idTermina, clan) {
        if(clan.email == null)
        {
            alert("Morate se registrovati da biste rezervisali termin");
            return;
            
        }
        
        fetch("https://localhost:5001/Api/ZakaziTermin/" + idTermina,
            { method: "PUT" }).then(
                s => {
                    if (s.ok) {
                        s.text().then(
                            t => {
                                
                                //alert("Uspesno ste rezervisali termin!");
                                alert(t);

                                let termini = this.container.querySelector(".TabelaTermini");

                                let tf = this.container.querySelector(".TreningForma");
                                if (tf !== null) {
                                    let rod = termini.parentNode;
                                    rod.removeChild(termini);
                                
                                    this.pretrazi(tf);
                                }
                                let trTerm = this.container.querySelector(".TrenerTabela");
                                let gk = this.container.querySelector(".GlavniKontejner");
                                if (gk !== null) {
                                    let rod = termini.parentNode;
                                    rod.removeChild(termini);
                                    this.crtajTrenerTabelu(gk);
                                }

                                //
                                //this.pretrazi(host);

                            }
                        )
                    }

                    else
                        throw s;
                }



            ).catch(err => err.text().then(errMsg => alert(errMsg)));


    }


    crtajTrenerTabelu(host) {
        

        var url = "https://localhost:5001/Api/TerminiTrenera/" + this.clan.email + "/" + this.id;

        fetch(url, {
            method: "GET",

            headers: {
                'Content-Type': 'application/json'
            }

        }).then(s => {
            if (s.ok) {

                s.json().then(data => {

                    var tabela = this.napraviTabelicu(host);
                    tabela.className = "TrenerTabela";

                    data.forEach(element => {

                        var p = new Termin(element.idTermina, this.id, this.naziv, element.trening, element.dan, element.vreme, element.trener, element.slobodnaMesta);

                        p.dodajUTabelicu(tabela);


                    });
                    this.izmeni(host);
                    this.izbrisi(host);
                    
                })
            }
        })

    }


    napraviTabelu(host) {
        var teloTabele = host.querySelector(".TabelaPodaci");

        if (teloTabele !== null) {
            var roditelj = teloTabele.parentNode;
            roditelj.removeChild(teloTabele);
        }


        teloTabele = document.createElement("tbody");
        teloTabele.className = "TabelaPodaci";
        host.appendChild(teloTabele);


        var tr = document.createElement("tr");
        var zag = ["TRENING", "DAN", "VREME", "TRENER", "SLOBODNA MESTA", ""];
        zag.forEach(el => {
            var th = document.createElement("th");
            th.innerHTML = el;
            tr.appendChild(th);
        })

        teloTabele.appendChild(tr);

        return teloTabele;
    }

    napraviTabelicu(host) {
        var teloTabele = host.querySelector(".TabelaTerminPodaci");

        if (teloTabele !== null) {
            var roditelj = teloTabele.parentNode;
            roditelj.removeChild(teloTabele);
        }


        teloTabele = document.createElement("tbody");
        teloTabele.className = "TabelaTerminPodaci";
        host.appendChild(teloTabele);


        var tr = document.createElement("tr");
        var zag = ["TRENING", "DAN", "VREME", "TRENER", "SLOBODNA MESTA", ""];
        zag.forEach(el => {
            var th = document.createElement("th");
            th.innerHTML = el;
            tr.appendChild(th);
        })

        teloTabele.appendChild(tr);

        return teloTabele;
    }




    removeTrenerTabelu(host) {
        var TrenerForma = host.querySelector(".TrenerTabela");

        if (TrenerForma !== null) {
            let rod = TrenerForma.parentNode;
            rod.removeChild(TrenerForma);
        }
    }




    izmeni(host) {
        var tabela = host.querySelector(".TrenerTabela");//vraca 1.tabelu
        //console.log(tabela);
        var tRow = tabela.querySelectorAll(".redUtabeli");//sve redpve
        
        console.log("redovi" + tRow);

        tRow.forEach(red => {
            var btnIzmeni=red.querySelector(".btnIzmeni");
            btnIzmeni.onclick = (ev) => { this.crtajFormu(host, red.value);

                console.log("vrednost" + red.value);
            }
        })

    }

    brisiFormu(host) {
        var forma = host.querySelector(".forma");
        if (forma != null) {
            let roditelj = forma.parentNode;
            roditelj.removeChild(forma);
        }
    }
    crtajFormu(host, idTermina) {

       this.brisiFormu(host);
        var forma = host.querySelector(".TrenerRedovitb");

        while (forma !== null) {
            var rod = forma.parentNode;
            rod.removeChild(forma);
            forma = host.querySelector(".TrenerRedovitb");
        }

        var forma= document.createElement("div");
        forma.className="forma";

        var red = document.createElement("div");
        var labela = document.createElement("label");
        labela.innerHTML = "Novi dan:";
        red.appendChild(labela);
        let tb1 = document.createElement("input");

        tb1.setAttribute("type", "text");
        tb1.className = "tbNDanTren";

        red.appendChild(tb1);
        //korisnikForma.appendChild(red);
        red.className="TrenerRedovi";

        forma.appendChild(red);

        var red = document.createElement("div");
        var labela = document.createElement("label");
        labela.innerHTML = "Novo vreme:";
        red.appendChild(labela);
        let tb = document.createElement("input");

        tb.setAttribute("type", "text");
        tb.className = "tbNVremeTren";

        red.appendChild(tb);
        red.className="TrenerRedovi";

        //korisnikForma.appendChild(red);

        forma.appendChild(red);

        red = document.createElement("div");
        var btnPromeni = document.createElement("button");
        btnPromeni.onclick = (ev) => this.promeni(host, idTermina);
        btnPromeni.className = "TrenerDugmePromeni";
        btnPromeni.innerHTML = "Promeni";
        red.className = "TrenerDugmici";
        red.appendChild(btnPromeni);
        forma.appendChild(red);

        host.appendChild(forma);

    }

    promeni(host, idTermina) {

        var dan2 = host.querySelector(".tbNDanTren").value;
        if (dan2 === "") {
            alert("Nije unet dan treninga");
            return;

        }

        var vreme2 = host.querySelector(".tbNVremeTren").value;
        if (vreme2 === "") {
            alert("Nije uneto vreme treninga");
            return;

        }
        

        fetch("https://localhost:5001/Api/IzmeniTermin/" + idTermina + "/" + dan2 + "/" + vreme2,
            {
                method: "PUT"
            }).then(s => {
                if (s.ok) {

                    alert("Uspesno ste izmenili termin");
                    let termini = this.container.querySelector(".TabelaTermini");
                    let tf = this.container.querySelector(".TreningForma");
                    if (tf !== null) {
                        let rod = termini.parentNode;
                        rod.removeChild(termini);
                        this.pretrazi(tf);
                    }
                    let trTerm = this.container.querySelector(".TrenerTabela");
                    let gk = this.container.querySelector(".GlavniKontejner");
                    console.log(gk);
                    if (gk !== null) {
                        let rod = trTerm.parentNode;
                        rod.removeChild(trTerm);
                        this.crtajTrenerTabelu(gk);
                    }
                    ;

                }
                else {
                    throw s;
                }
            }).catch(err => {
                err.text().then(errMsg =>
                    alert(errMsg))
            });


    }
 

    izbrisi(host) {
        var tabela = host.querySelector(".TrenerTabela");//vraca 1.tabelu
        //console.log(tabela);
        var tRow = tabela.querySelectorAll(".redUtabeli");//sve redpve
        
        console.log("redovi" + tRow);

        tRow.forEach(red => {
            var btnObrisi=red.querySelector(".btnObrisi");
            btnObrisi.onclick = (ev) => { this.obrisi(host, red.value);
                //da se nadje dugme

                console.log("vrednost" + red.value);
            }
        })

    }

    obrisi(host, idTermina)
    {
        fetch("https://localhost:5001/Api/IzbrisiTermin/" + idTermina,
            {
                method: "DELETE",
                headers: {
                    'Content-Type': 'application/json',
                    'Accept': 'application/json'
                }

            }).then(s => {
                if (s.ok) {
                    alert("Izbrisan je termin");
                    console.log("termin id"+idTermina);

                    var tab=document.querySelector(".redUtabeli");
                    var rod=tab.parentNode;
                    rod.removeChild(tab);

                } else
                    throw s;
            }).catch(err => {
                console.log(err);
                err.text().then(errMsg => alert(errMsg));

            });
        }
    
 

}
