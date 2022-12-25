﻿async function CreateOgranizationsList() {
    const response = await fetch("/api/organization", {
        method: "GET",
        headers: {"Accept": "application/json" }
            });
    
    if (response.ok === true) {
                
                const organizations = await response.json();
    const selectList = userForm.orgDD;

        organizations.forEach(organization => {
                    var option = document.createElement("option");
    option.value = organization.orgId;
    option.text = organization.name;
    selectList.appendChild(option);
                });
            }
        }
    async function CreateEmployeesList() {
            
            const response = await fetch("/api/employee", {
        method: "GET",
    headers: {"Accept": "application/json" }
            });
    
    if (response.ok === true) {
                
                const employees = await response.json();
    const selectList = userForm.employeeDD;

                employees.forEach(employee => {
                    var option = document.createElement("option");
    option.value = employee.employeeId;
    option.text = employee.name;
    selectList.appendChild(option);
                });
            }
        }
    
    async function GetInvoices() {
            
            const response = await fetch("/api/invoice", {
        method: "GET",
    headers: {"Accept": "application/json" }
            });
    
    if (response.ok === true) {
                
                const invoices = await response.json();
    let rows = document.querySelector("tbody");
                invoices.forEach(user => {
                    const rowVal = row(user)
    
    rows.append(rowVal);
                });
            }
        }
    
    async function GetInvoice(id) {
            const response = await fetch("/api/invoice/" + id, {
        method: "GET",
    headers: {"Accept": "application/json" }
            });
    if (response.ok === true) {
                const report = await response.json();
    const form = document.forms["userForm"];
    form.elements["id"].value = report.releaseInvoiceId;
    form.elements["createDate"].value = report.createDate;
    form.elements["number"].value = report.number;
    form.elements["orgDD"].value = report.orgId;
    form.elements["roomDD"].value = report.roomId;
    form.elements["sum"].value = report.sum;
    form.elements["employeeDD"].value = report.employeeId;
            }
        }
    
    async function CreateInvoice(reportCreateDate, reportNumber, reportOrgId, reportRoomId, reportSum, reportEmployeeId) {
        console.log(reportCreateDate)
            console.log(reportNumber)
    console.log(reportOrgId)
    console.log(reportRoomId)
    console.log(reportSum)
    console.log(reportEmployeeId)
    const response = await fetch("/api/invoice", {
        method: "POST",
    headers: {"Accept": "application/json", "Content-Type": "application/json" },
    body: JSON.stringify({
        reciveDate: new Date("2017-01-26"),
    createDate: new Date("2019-01-26"),
    volume: parseInt(reportVolume,10),
    sum: parseInt(reportCost, 10),
    orgId: parseInt(reportCustomerId, 10),
    employerId: 40,
    roomId: 40
                })
            });
    if (response.ok === true) {
                const user = await response.json();
    reset();
    document.querySelector("tbody").append(row(user));
            }
        }
    
    async function EditReport(reportId, reportCreateDate, reportNumber, reportOrgId, reportRoomId, reportSum, reportEmployeeId) {
            const response = await fetch("/api/ReleaseReports/", {
        method: "PUT",
    headers: {"Accept": "application/json", "Content-Type": "application/json" },
    body: JSON.stringify({
        ReleaseReportId: parseInt(reportId, 10),
    reciveDate: new Date("2017-01-26"),
    createDate: new Date("2019-01-26"),
    volume: parseInt(reportVolume, 10),
    sum: parseInt(reportCost, 10),
    orgId: parseInt(reportCustomerId, 10),
    employerId: 40,
    roomId: 40
                })
            });
    if (response.ok === true) {
                const user = await response.json();
    reset();
    document.querySelector("tr[data-rowid='" + user.releaseReportId + "']").replaceWith(row(user));
            }
        }
    
    async function DeleteInvoice(id) {
            const response = await fetch("/api/invoice/" + id, {
                method: "DELETE",
                headers: {"Accept": "application/json" }
            });
    if (response.ok === true) {
        document.querySelector("tr[data-rowid='" + id + "']").remove();
            }
    }

    
    function reset() {
            const form = document.forms["userForm"];
    form.reset();
    form.elements["id"].value = 0;
    }
    
    function row(releaseInvoice) {

            const tr = document.createElement("tr");
    tr.setAttribute("data-rowid", releaseInvoice.releaseInvoiceId);

    const idTd = document.createElement("td");
    idTd.append(releaseInvoice.releaseInvoiceId);
    tr.append(idTd);

    const createDateTd = document.createElement("td");
    createDateTd.append(releaseInvoice.createDate);
    tr.append(createDateTd);

    const numberTd = document.createElement("td");
    numberTd.append(releaseInvoice.number);
    tr.append(numberTd);

    const orgTd = document.createElement("td");
    orgTd.append(releaseInvoice.organization);
    tr.append(orgTd);

    const roomTd = document.createElement("td");
    roomTd.append(releaseInvoice.roomId);
    tr.append(roomTd);

    const sumTd = document.createElement("td");
    sumTd.append(releaseInvoice.sum);
    tr.append(sumTd);

    const employeeTd = document.createElement("td");
    employeeTd.append(releaseInvoice.employee);
    tr.append(employeeTd);

    const linksTd = document.createElement("td");

    const editLink = document.createElement("a");
    editLink.setAttribute("data-id", releaseInvoice.releaseInvoiceId);
    editLink.setAttribute("style", "cursor:pointer;padding:15px;");
    editLink.append("Изменить");
            editLink.addEventListener("click", e => {

        e.preventDefault();
    GetInvoice(releaseInvoice.releaseInvoiceId);
            });
    linksTd.append(editLink);

    const removeLink = document.createElement("a");
    removeLink.setAttribute("data-id", releaseInvoice.releaseInvoiceId);
    removeLink.setAttribute("style", "cursor:pointer;padding:15px;");
    removeLink.append("Удалить");
            removeLink.addEventListener("click", e => {

        e.preventDefault();
    DeleteInvoice(releaseInvoice.releaseInvoiceId);
            });

    linksTd.append(removeLink);
    tr.appendChild(linksTd);

    return tr;
        }
   
    document.getElementById("reset").click(function (e) {

        e.preventDefault();
    reset();
        })

        
   document.forms["userForm"].addEventListener("submit", e => {
    e.preventDefault();
    const form = document.forms["userForm"];
    const id = form.elements["id"].value;
    const createDate = form.elements["createDate"].value;
    const number = form.elements["number"].value;
    const orgId = form.elements["orgDD"].value;
    const roomId = form.elements["roomDD"].value;
    const sum = form.elements["sum"].value;
    const employeeId = form.elements["employeeDD"].value;
    if (id == 0)
    CreateInvoice(createDate, number, orgId, roomId, sum, employeeId);
    else
    EditInvoice(id, createDate, number, orgId, roomId, sum, employeeId);
        });
    async function Start() {
        await CreateOgranizationsList();
    await CreateEmployeesList();
    await GetInvoice();
        }
    Start()