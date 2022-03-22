import { Teretana } from "./Teretana.js";

export class Clan {
    constructor(teretana) {
        this.ime = null;
        this.prezime = null;
        this.email = null;
        this.lozinka = null;
        this.trener = false;
        this.container = null;
        this.teretana = teretana;
    }
    crtajClana(host, idTeretane) {
        let pom = this.teretana.container.querySelector(".TrenerForma");

        if (pom !== null) {
            let rod = pom.parentNode;
            rod.removeChild(pom);
        }

        var clanForma = host.querySelector(".ClanForma");
        if (clanForma !== null) {
            var rod = clanForma.parentNode;
            rod.removeChild(clanForma);
        }

        clanForma = document.createElement("div");
        clanForma.className = "ClanForma";
        this.container = clanForma;
        host.appendChild(clanForma);

        var pod = ["Ime", "Prezime"];


        var red = document.createElement("div");
        red.className = "ClanRed";

        var labela = document.createElement("label");
        labela.className = "ClanLabela";

        pod.forEach(p => {
            red = document.createElement("div");
            red.className = "ClanRed";
            labela = document.createElement("label");
            labela.innerHTML = p + ":";
            labela.className = "ClanLabela"
            let tb = document.createElement("input");

            tb.setAttribute("type", "text");
            tb.className = "ClanTextBox" + p;

            red.appendChild(labela);
            red.appendChild(tb);
            clanForma.appendChild(red);

        });


        this.crtajPolja(clanForma);


        var btnRegistrujSe = document.createElement("button");
        btnRegistrujSe.className="btnOk";
        btnRegistrujSe.onclick = (ev) => this.registracija(this.container,idTeretane);
        btnRegistrujSe.innerHTML = "OK";

        red = document.createElement("div");
        red.className = "ClanDugmici";

        red.appendChild(btnRegistrujSe);
        clanForma.appendChild(red);
    }
    crtajPolja(host) {

        var pod = ["email", "lozinka"];
        var red = document.createElement("div");
        red.className = "ClanRed";

        var labela = document.createElement("label");
        labela.className = "ClanLabela"



        pod.forEach(p => {
            red = document.createElement("div");
            red.className = "ClanRed";
            labela = document.createElement("label");
            labela.innerHTML = p + ":";
            labela.className = "ClanLabela"
            let tb = document.createElement("input");

            if (p === "lozinka")
                tb.setAttribute("type", "password");
            else
                tb.setAttribute("type", "text");
            tb.className = "ClanTextBox" + p;
            red.appendChild(labela);
            red.appendChild(tb);
            host.appendChild(red);

        });



    }
    crtajClanaSkraceno(host, idTeretane) {
        var clanForma = host.querySelector(".ClanForma");
        if (clanForma !== null) {
            var rod = clanForma.parentNode;
            rod.removeChild(clanForma);
        }

        clanForma = document.createElement("div");
        clanForma.className = "ClanForma";
        this.container = clanForma;
        host.appendChild(clanForma);

        this.crtajPolja(clanForma);

        red = document.createElement("div");
        var cb = document.createElement("input");
        cb.type = "checkbox";
        cb.className = "clanTrener";
        var l = document.createElement("label");
        l.innerHTML = "Trener:";
        l.className="LabelaTrener";
        red.appendChild(l);
        red.appendChild(cb);
        clanForma.appendChild(red);

        var btnUlogujSe = document.createElement("button");
        btnUlogujSe.className="btnOk";
        btnUlogujSe.onclick = (ev) => this.logovanje(this.container, idTeretane );
        btnUlogujSe.innerHTML = "OK";



        var red = document.createElement("div");
        red.className = "ClanDugmici";
        red.appendChild(btnUlogujSe);

        clanForma.appendChild(red);

    }
    proveriClana(host) {
        if (host.querySelector(".ClanTextBoxemail").value !== "")
            this.email = host.querySelector(".ClanTextBoxemail").value;
        else {
            alert("Nije uneto korisnicko ime");
            return;
        }
        if (host.querySelector(".ClanTextBoxlozinka").value !== "")
            this.lozinka = host.querySelector(".ClanTextBoxlozinka").value;
        else {
            alert("Nije uneta lozinka");
            return;
        }



    }
    kreirajClana(host) {

        if (host.querySelector(".ClanTextBoxIme").value !== "")
            this.ime = host.querySelector(".ClanTextBoxIme").value;
        else {
            alert("Nije uneto ime");
            return;
        }

        if (host.querySelector(".ClanTextBoxPrezime").value !== "")
            this.prezime = host.querySelector(".ClanTextBoxPrezime").value;
        else {
            alert("Nije uneto prezime");
            return;
        }

        this.proveriClana(host);


    }
    logovanje(host, idTeretane) {

        this.proveriClana(host);
        var cb = host.querySelector(".clanTrener");
        this.trener = cb.checked;
        if (this.email === "") {
            alert("Niste uneli korisnicko ime");
            return;
        }
        if (this.lozinka === "") {
            alert("Niste uneli sifru");
            return;
        }

        fetch("https://localhost:5001/Api/UlogujSe/" + idTeretane+ "/"+ this.email + "/" + this.lozinka + "/" + this.trener)
            .then(s => {
                if (s.ok) {   
                    alert("uspesno ste se ulogovali");
                    s.json().then(
                        data => {
                            this.ime = data.ime;
                            this.prezime = data.prezime;
                            if (this.trener) {
                                let host = this.teretana.container.querySelector(".GlavniKontejner");
                               
                                this.teretana.crtajTrenerTabelu(host);
                            }
                        }
                        
                    )
                    this.teretana.clan = this;
                    let rod = host.parentNode;
                    rod.removeChild(host);
                }
                else {
                    alert("Ne postoji clan u ovoj teretani!");
                    let host = this.teretana.container.querySelector(".GlavniKontejner");
                    this.teretana.removeTrenerFormu(host);
                    throw s;

                }
            }).catch(err =>
                err.text().then(errMsg =>
                    alert(errMsg)));

    }

    registracija(host, idTeretane) {

        this.kreirajClana(host);
        //this.trener = false;
        fetch("https://localhost:5001/Api/RegistrujSe/"+ idTeretane+ "/"+this.ime + "/" + this.prezime + "/" + this.email + "/" + this.lozinka,
            {


                method: "POST",


                headers: {
                    "Content-type": "application/json; charset=UTF-8"
                }
            }).then(s => {
                let host = this.teretana.container.querySelector(".ClanForma");
                if (host !== null) {
                    let rod = host.parentNode;
                    rod.removeChild(host);
                }


                if (s.ok) {

                    this.teretana.clan = this;
                    alert("uspesno ste se registrovali");

                }
                else {

                    throw s;

                }
            }).catch(err =>
                err.text().then(errMsg =>
                    alert(errMsg)));


    }
}
