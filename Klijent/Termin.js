import { Teretana } from "./Teretana.js";
import { Clan } from "./Clan.js";

export class Termin{
    constructor(id, idTeretane, Teretana , nazivTreninga, dan, vreme, imeTrenera, slobodnaMesta)
    {
        this.id=id;
        this.nazivTreninga=nazivTreninga;
        this.vreme=vreme;
        this.dan=dan;
        this.imeTrenera=imeTrenera;
        this.idTeretane=idTeretane;
        this.Teretana=Teretana;
        this.slobodnaMesta=slobodnaMesta;
    }

    dodajUTabelu(host)
    {
        var tr=document.createElement("tr");
        tr.className="tabelRow";
        tr.value=this.id;
        //console.log(this.id);
        //tr.onclick=(ev)=>{
            //this.zakazi(host);
            console.log(tr.value);
        
            
        

        var pod=["nazivTreninga", "vreme", "dan", "imeTrenera", "slobodnaMesta", "btnZakazi"];

        var td=document.createElement("td");
        td.innerHTML=this.nazivTreninga;
        tr.appendChild(td);

        td = document.createElement("td");
        td.innerHTML = this.dan;
        tr.appendChild(td);

        td = document.createElement("td");
        td.innerHTML = this.vreme;
        tr.appendChild(td);

        td = document.createElement("td");
        td.innerHTML = this.imeTrenera;
        tr.appendChild(td);

        td=document.createElement("td");
        td.innerHTML=this.slobodnaMesta;
        tr.appendChild(td);

        let btnZakazi = document.createElement("buton");
        btnZakazi.innerHTML=" Zakazi ";
        btnZakazi.className="btnZakazi";
            //btnIzmeni.onclick = (ev) => this.izmeni();
        tr.appendChild(btnZakazi);

        host.appendChild(tr);

    }

    

       dodajUTabelicu(host)
        {
            var tr=document.createElement("tr");
            tr.className="redUtabeli";
            tr.value=this.id;
            //console.log(this.id);
            //tr.onclick=(ev)=>{
                //this.zakazi(host);
                console.log(tr.value);
    
            var pod=["nazivTreninga", "vreme", "dan", "imeTrenera", "slobodnaMesta", "btnIzmeni", "btnObrisi"];
    
            var td=document.createElement("td");
            td.innerHTML=this.nazivTreninga;
            tr.appendChild(td);
    
            td = document.createElement("td");
            td.innerHTML = this.dan;
            tr.appendChild(td);
    
            td = document.createElement("td");
            td.innerHTML = this.vreme;
            tr.appendChild(td);
    
            td = document.createElement("td");
            td.innerHTML = this.imeTrenera;
            tr.appendChild(td);
    
            td=document.createElement("td");
            td.innerHTML=this.slobodnaMesta;
            td.className="slobodnaMesta";
            tr.appendChild(td);

            
            let btnIzmeni = document.createElement("buton");
            btnIzmeni.innerHTML=" Izmeni ";
            btnIzmeni.className="btnIzmeni";
            tr.appendChild(btnIzmeni);

            let btnObrisi = document.createElement("buton");
            btnObrisi.innerHTML=" Obrisi ";
            btnObrisi.className="btnObrisi";
            
            tr.appendChild(btnObrisi);



            host.appendChild(tr);
    
        }
    
                    
    }

    

