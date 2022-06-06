
function printFilter(data) {
    fetchPost("Orders/FilterOrder", "json", data, function (res) {
        configurationGlobalJSON = {
            encabezados: ["No.", "Número de Documento", "Cliente", "Grupo", "Fecha y Hora", "Total"],
            propiedades: ["docEntry", "docNum", "cardName", "groupName", "docDate", "docTotal"],
            idPintado: "orders",
            visualizacion: true,
            id: "docEntry",
            res: res
        }
        var contenido = "";
        contenido += generateTable(res)
        console.log(contenido)
        document.getElementById(configurationGlobalJSON.idPintado).innerHTML = contenido;
    })
}

async function fetchGet(url, tiporespuesta, callback) {
    try {
        var root = document.getElementById("hdfOculto").value;
        var path = window.location.protocol + "//" + window.location.host + "/" + root
            + url

        var res = await fetch(path)
        if (tiporespuesta == "json")
            res = await res.json();
        else if (tiporespuesta == "text")
            res = await res.text();
        callback(res)
    } catch (e) {
        alert("Ocurrion un error");
    }
}

async function fetchPost(url, tiporespuesta, form, callback) {
    try {
        var root = document.getElementById("hdfOculto").value;
        var path = window.location.protocol + "//" + window.location.host + "/" + root
            + url
        var res = await fetch(path, {
            method: "POST",
            body: form
        });
        if (tiporespuesta == "json")
            res = await res.json();
        else if (tiporespuesta == "text")
            res = await res.text();
        callback(res)
    } catch (e) {
        console.log(e)
        alert("Ocurrion un error");
    }
}

/**
 * configurationGlobalJSON = {
 * encabezados: [],
 * propiedades: [],
 * idPintado: ""
 * }
 * */
var configurationGlobalJSON;
function print(configurationJSON) {
    configurationGlobalJSON = configurationJSON;
    console.log(configurationGlobalJSON)
    fetchGet(configurationJSON.url, "json", function (res) {
        console.log(res)
        var contenido = "";
        contenido += generateTable(res)
        console.log(contenido)
        document.getElementById(configurationJSON.idPintado).innerHTML = contenido;
    })
}

function printDetalle(configurationJSON) {
    configurationGlobalJSON = configurationJSON;
    fetchGet(configurationJSON.url, "json", function (res) {
        console.log(res)
        var contenido = "";
        contenido += generateTable(res.details)
        console.log(contenido)
        document.getElementById(configurationJSON.idPintado).innerHTML = contenido;
    })
}

function printSelect(data, idcontrol, propiedadId, propiedadNombre) {
    var contenido = "";
    var objActual;
    for (var i = 0; i < data.length; i++) {
        objActual = data[i];
        contenido += "<option value='" + objActual[propiedadId] + "'>" + objActual[propiedadNombre] + "</option>"
    }

    document.getElementById(idcontrol).innerHTML = contenido;
}

function generateTable(res) {
    var contenido = "";
    var cabeceras = configurationGlobalJSON.encabezados;
    var nombrepropiedades = configurationGlobalJSON.propiedades;

    // Dibujar encabezados
    contenido += "<table class='table'>";
    contenido += "<thead class='thead-dark'>";
    contenido += "<tr>";
    for (var i = 0; i < cabeceras.length; i++) {
        contenido += "<th>" + cabeceras[i] + "</th>";
    }
    if (configurationGlobalJSON.visualizacion) {
        contenido += `<th>Opciones</th>`;
    }
    contenido += "</tr>";
    contenido += "</thead>"

    var obj;
    var propiedadActual;

    // Dibujar elementos
    contenido += "<tbody>";
    for (var i = 0; i < res.length; i++) {
        obj = res[i]
        contenido += "<tr>";
        for (var j = 0; j < nombrepropiedades.length; j++) {
            propiedadActual = nombrepropiedades[j]
            contenido += "<td>" + obj[propiedadActual] + "</td>";

            
        }
        if (configurationGlobalJSON.visualizacion) {
            contenido += `<td><button type="button" class="btn btn-primary" onclick="Visualizar(${obj[configurationGlobalJSON.id]})" data-toggle="modal" data-target="#exampleModal">Detalle</button></td>`;
        }
        contenido += "</tr>";
    }
    contenido += "</tbody>"
    contenido += "</table>";
    return contenido;
}

function limpiarForm(idForm) {
    var elementosName = document.querySelectorAll("#" + idForm + " [name]");
    var elementoActual;
    var elementoName;
    for (var i = 0; i < elementosName.length; i++) {
        elementoActual = elementosName[i]
        elementoName = elementoActual.name;
        setName(elementoName, "");
    }
}

function get(idcontrol) {
    return document.getElementById(idcontrol).value;
}

function set(idcontrol, valor) {
    document.getElementById(idcontrol).value = valor;
}

function setName(namecontrol, valor) {
    document.getElementsByName(namecontrol)[0].value = valor;
}