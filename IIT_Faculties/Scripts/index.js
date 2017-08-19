function faculty(data){
    this.Name = ko.observable(data.Name);
    this.Designation = ko.observable(data.Designation);
    this.Qualtification = ko.observable(data.Qualtification);
    this.DBLP = ko.observable(data.DBLP);
    this.GoogleScholar = ko.observable(data.GoogleScholar);
    this.Academia = ko.observable(data.Academia);
    this.ResearchGate = ko.observable(data.ResearchGate);
    this.Status = ko.observable(data.Status);
}

function facultyModel() {
    var self = this;
    self.faculties = ko.observableArray("");
    self.query = ko.observable("");
    self.selectedLayer = ko.observable();
    self.selectedLayerType = ko.observable();
    self.Template = ko.observable("default-template");

    self.filteredFaculties = ko.computed(function () {
        var filter = self.query().toLowerCase();
        if (!filter) {
            return self.faculties();
        } else {
            return ko.utils.arrayFilter(self.faculties(), function (item) {
                return item.Name().toLowerCase().indexOf(filter) !== -1;
            });
        }
    });

    $.getJSON('/Faculty/GetFaculties', function (data) {
        var mappedData = $.map(data, function (item) { return new faculty(item) });
        self.faculties(mappedData);
    });

    //operations
    self.showDetails = function (faculty) { };
    self.removeFaculty = function (faculty) { self.faculties.destroy(faculty) };
    self.save = function () {
        $.ajax("/tasks", {
            data: ko.toJSON({ faculties: self.faculties }),
            type: "post",
            contentType: "application/json",
            success: function (result) {
                alert(result)
            }
        });
    };
}

var GetFacultyModel = new facultyModel();

$(document).ready(function () {
    ko.applyBindings(GetFacultyModel);
});

//template operation
$(document).on("click", ".change-default", null, function (ev) {
    GetFacultyModel.Template("default-template");
})
$(document).on("click", ".change-create", null, function (ev) {
    GetFacultyModel.Template("create-template");
})
$(document).on("click", ".change-edit", null, function (ev) {
    GetFacultyModel.Template("edit-template");
})
$(document).on("click", ".change-detail", null, function (ev) {
    GetFacultyModel.Template("details-template");
})