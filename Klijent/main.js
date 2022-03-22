import { Teretana } from "./Teretana.js";
import { Vrsta } from "./Vrsta.js";



fetch("https://localhost:5001/Api/Teretane").then(p => {
    if (p.ok) {
        p.json().then(
            
            teretane => {
                teretane.forEach(element => {
                   /* console.log("bla");
                    var divb = document.createElement("div");
                    divb.className = "izborTeretane";
                    divb.innerHTML = element.naziv;
                    document.body.appendChild(divb);

                    divb.onclick = (ev) => {
                        let listaVrsta = [];
                        element.vrste.forEach( obj => {
                            let t = new Vrsta(obj.id, obj.naziv, null);
                            listaVrsta.push(t);
                        });

                       */ 
                        let listaVrsta = [];
                        element.vrste.forEach( obj => {
                            let t = new Vrsta(obj.id, obj.naziv, null);
                            listaVrsta.push(t)});

                        var b = new Teretana(element.id, element.naziv, listaVrsta);
                        //var pozadina = document.body.querySelector(".pozadina");
                        var pozadina = document.createElement("div");
                        pozadina.className="pozadina";
                        document.body.appendChild(pozadina);
                       /* if (pozadina !== null){
                            var rod = pozadina.parentNode;
                            rod.removeChild(pozadina);
                        }
                     /*   var izborTeretane = document.body.querySelectorAll(".izborTeretane");

                        izborTeretane.forEach(element => {
                            let rod = element.parentNode;
                            rod.removeChild(element);
                        });
                        
                        izborTeretane.forEach(element => {
                          pozadina = document.createElement("div");
                          pozadina.className="pozadina";
                          document.body.appendChild(pozadina);
                          b.crtajTeretanu(pozadina);
                        });
                        */
                       b.crtajTeretanu(pozadina);

                    //};
                });
            }
        );
    }
});
