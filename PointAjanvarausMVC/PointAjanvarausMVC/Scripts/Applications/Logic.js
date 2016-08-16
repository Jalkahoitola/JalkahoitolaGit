/// <reference path="../typings/jquery/jquery.d.ts" />
var RekisteriArkisto = (function () {
    function RekisteriArkisto() {
    }
    return RekisteriArkisto;
}());
function initArkistointi() {
    $("#ArkistointiButton").click(function () {
        //alert("Toimii!");
        var arkistoVuosikurssi = $("#ArkistoVuosikurssi").val();
        var tunnari = $("#Tunnus").val();
        alert("A: " + arkistoVuosikurssi + ", H:" + tunnari);
        //määritetään muuttuja:
        var data = new RekisteriArkisto();
        data.ArkistoVuosikurssi = arkistoVuosikurssi;
        data.Tunnari = tunnari;
        //lähetetään JSON-muotoista dataa palvelimelle
        $.ajax({
            type: "POST",
            url: "/Ajanvaraus/RekisteriArkisto",
            data: JSON.stringify(data),
            contentType: "applications/json",
            success: function (data) {
                if (data.success == true) {
                    alert("Tietojen arkistointi talletettu.");
                }
                else {
                    alert("Virhe : " + data.error);
                }
            },
            dataType: "json"
        });
    });
}
//# sourceMappingURL=Logic.js.map