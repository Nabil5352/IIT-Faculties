function faculty(data) {
    this.ID = ko.observable(data.ID)
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
    self.Template = ko.observable("default-template");

    //new observables
    self.NewName = ko.observable("");
    self.NewDesignation = ko.observable("");
    self.NewQualification = ko.observable("");
    self.NewDBLP = ko.observable("");
    self.NewGoogleScholar = ko.observable("");
    self.NewAcademia = ko.observable("");
    self.NewResearchGate = ko.observable("");
    self.selectedStatus = ko.observable();
    var Status = function (key, value) {
        this.value = value;
        this.key = key;
    };
    self.CurrentStatus = ko.observableArray([
        new Status("On Leave", 0),
        new Status("On Duty", 1),
        new Status("Study Leave", 2)
    ]);
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
    self.createNew = function () {
        var submitData ={
            Name: this.NewName(),
            Designation: this.NewDesignation(),
            Qualtification: this.NewQualification(),
            DBLP: this.NewDBLP(),
            Academia: this.NewAcademia(),
            GoogleScholar: this.NewGoogleScholar(),
            ResearchGate: this.NewResearchGate(),
            Status: this.selectedStatus()
        };

        $.ajax("/Faculty/Create", {
            data: JSON.stringify(submitData),
            type: "post",
            contentType: "application/json",
            success: function (result) {
                alert(result)
            },
            error: function () {
                alert("ERROR Saving");
            },
        });
    };

    self.showDetails = function (faculty) { };
    self.removeFaculty = function (item) {
        if (confirm('Are you sure to Delete "' + item.Name() + '" ??')) {
            var id = item.ID();
            $.ajax({
                url: 'Faculty/Delete/'+id,
                type: 'POST',
                contentType: 'application/json',
                data: id,
                success: function (data) {
                    self.faculties.remove(item);
                }
                }).fail(
                 function (xhr, textStatus, err) {
                     console.log(err);
                 });
        }
    };
    self.save = function () {
        $.ajax("Faculty/Create", {
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