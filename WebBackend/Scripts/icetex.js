function SoloLectura()
{
    $(".soloLectura").attr('readonly', 'readonly');
}

function CalcularFechaPep(fechaDesv, fechaDesvCargo) {
	
	var fechaDes = fechaDesv.val()
	if (fechaDes != undefined && fechaDes != "") {
		var dateString = fechaDes.split("/");
		var newDate = new Date(dateString[2], (dateString[1] - 1), dateString[0]);
		fechaDesvCargo.val(newDate.getDate() + "/" + (newDate.getMonth() + 1) + "/" + (newDate.getFullYear() + 2));
	}
}

function HabilitarBotonAgregarPEP() {
    var mostrar = false;

    if ($("#DECRETO_1674").val() == "1") {
        mostrar = true;
    }

    if ($("#REP_ORG_INTERNACIONAL").val() == "1") {
        mostrar = true;
    }

    if ($("#RECONOCIMIENTO_PUB").val() == "1") {
        mostrar = true;
    }

    if ($("#VINCULO_PEP").val() == "1") {
        mostrar = true;
    }

    if (mostrar) {
        $("#btnAgregarPEP").removeAttr('disabled');
        $("#ENTIDAD_PEP").removeAttr('disabled');
        $("#ID_CARGO_PEP").removeAttr('disabled');
        $("#FEC_VINCULA_PEP").removeAttr('disabled');
        $("#FEC_DESVINCULA_PEP").removeAttr('disabled');
    } else {
        $("#btnAgregarPEP").attr('disabled', 'disabled');
        $("#ENTIDAD_PEP").attr('disabled', 'disabled');
        $("#ID_CARGO_PEP").attr('disabled', 'disabled');
        $("#FEC_VINCULA_PEP").attr('disabled', 'disabled');
        $("#FEC_DESVINCULA_PEP").attr('disabled', 'disabled');
    }
}

function CargarCiudades(departamentoId, ddl) {

	$.ajax({
		type: 'POST',
        url: "/PersonaNatural/ObtenerCiudades",
		dataType: 'json',
		data: { departamentoId: departamentoId },
		success: function (municipio) {
		
			ddl.append('<option>Seleccione un valor </option>');
			$.each(municipio, function (i, municipio) {
				ddl.append('<option value="' + municipio.Value + '">' +
					municipio.Text + '</option>');
			});
		},
		error: function (ex) {
			//alert('Error: ' + ex);
		}
	});
}

function CargarCodigoCiiu(actividadId, dllC)
{

	$.ajax({
		type: 'POST',
		url: "/PersonaNatural/CodigoCiiuPorActividadConsultar",
		dataType: 'json',
		data: { actividadId: actividadId },
		success: function (codigosCiiu) {
	
			dllC.append('<option>Seleccione un valor </option>');
			$.each(codigosCiiu, function (i, codigosCiiu) {
				dllC.append('<option value="' + codigosCiiu.Value + '">' +
					codigosCiiu.Text + '</option>');
			});
		},
		error: function (ex) {
			alert('Error: ' + ex);
		}
	});
}

