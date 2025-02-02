var dtble;
$(document).ready(function () {
    loadData();
});

function loadData() {
    dtble = $("#myTable").DataTable({
        "ajax": {
            "url": "/Answers/GetData"
        },
        "columns": [
            { "data": "optionText" },
            { "data": "isCorrect" },
            { "data": "questionId" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <a href="/Answers/Edit/${data}" class="btn btn-success">Edit</a>
                        <a href="/Answers/Delete/${data}" class="btn btn-danger">Delete</a>
                    `;
                }
            }
        ]
    });
}