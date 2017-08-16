FacultyviewModel = {
    facultyCollection: ko.observableArray()
};

$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "/Faculty/GetFaculties",
    }).done(function (data) {
        $(data).each(function (index, element) {
            FacultyviewModel.facultyCollection.push(element);
        });
        ko.applyBindings(FacultyviewModel);
    }).error(function () {
        alert("Error");
    });
});