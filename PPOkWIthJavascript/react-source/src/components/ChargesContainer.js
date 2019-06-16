import React from 'react';

export default class ChargesContainer extends React.Component {
    state = {
        items: [],
        newItem: {
            type: '',
            amount: ''
        },
        orderedByAmount: null
    };

    componentDidMount() {
        fetch('api/item')
        .then((resp) => resp.json())
        .then(function(data) {
            let rows = [];
            let orderedRows = [];
            for(let i =0; i< data.length; i++) {
                rows.push(
                    <tr>
                        <th scope="row">{data[i].Amount}</th>
                        <td>{data[i].Type}</td>
                        <td>{data[i].TransactionDate}</td>
                    </tr>
                )
                orderedRows.push(
                    <tr>
                        <th scope="row">{data[i].Amount}</th>
                        <td>{data[i].Type}</td>
                    </tr>
                )
            }

            this.setState({
                items: data,
                orderedByAmount: orderedRows
            });
        })
        .catch(function(error) {
            console.log(JSON.stringify(error));
        });
    }

    handleSubmit(event){
        event.preventDefault();

        const newItem = this.state.newItem;

        fetch('api/PostData', {
            method: 'post',
            headers: {'Content-Type':'application/json'},
            body: newItem
        });
    };

    render() {
        return (
            <div className="container">
                <form className="form-inline float-right">
                    <div className="form-group mb-2">
                        <input type="text" className="form-control-plaintext bg-light" id="amount" placeholder="Charge Amount" />
                    </div>
                    <div className="form-group mx-sm-3 mb-2">
                        <input type="text" className="form-control-plaintext bg-light" id="type" placeholder="Charge Type" />
                    </div>
                    <button type="submit" className="btn btn-primary mb-2">Submit</button>
                </form>
                <table className="table table-bordered table-hover">
                    <thead className="table-dark text-dark" style={{color: "white !important"}}>
                        <tr>
                            <th>
                                Amount
                            </th>
                            <th>
                                Type
                            </th>
                            <th>
                                Transaction Date
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.items}
                    </tbody>
                </table>
                <table className="table table-bordered table-hover">
                    <thead className="table-dark text-dark" style="color: white !important">
                        <tr>
                            <th>
                                Type
                            </th>
                            <th>
                                Amount
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.orderedByAmount}
                    </tbody>
                </table>
            </div>
        );
    }
}










/**
 @model PPOkNoJavascript.ViewModels.ItemDetailsViewModel
@{
    ViewData["Title"] = "Index";
}
@*action="@Url.Action("Create", "Item")"*@
<form className="form-inline float-right" method="post" asp-action="Create">
    <div className="form-group mb-2">
        <input type="text" className="form-control-plaintext bg-light" asp-for="Item.Amount" id="amount" placeholder="Charge Amount">
    </div>
    <div className="form-group mx-sm-3 mb-2">
        <input type="text" className="form-control-plaintext bg-light" asp-for="Item.Type" id="type" placeholder="Charge Type">
    </div>
    <button type="submit" className="btn btn-primary mb-2">Submit</button>
</form>

<h1>@Model.PageTitle</h1>

<table className="table table-bordered table-hover">
    <thead className="table-dark text-dark" style="color: white !important">
        <tr>
            <th>
                Amount
            </th>
            <th>
                Type
            </th>
            <th>
                Transaction Date
            </th>
        </tr>
    </thead>
    <tbody>
        @foreach (var item in Model.Items.OrderByDescending(i => i.TransactionDate))
        {
            <tr>
                <td>
                    @Html.DisplayFor(modelItem => item.Amount)
                </td>
                <td>
                    @Html.DisplayFor(modelItem => item.Type)
                </td>
                <td>
                    @Html.DisplayFor(modelItem => item.TransactionDate)
                </td>
            </tr>
        }
    </tbody>
</table>

<table className="table table-bordered table-hover">
    <thead className="table-dark text-dark" style="color: white !important">
        <tr>
            <th>
                Type
            </th>
            <th>
                Amount
            </th>
        </tr>
    </thead>
    <tbody>
        @foreach (var item in Model.Items.OrderBy(i => i.Amount))
        {
            <tr>
                <td>
                    @Html.DisplayFor(modelItem => item.Type)
                </td>
                <td>
                    @Html.DisplayFor(modelItem => item.Amount)
                </td>
            </tr>
        }
    </tbody>
</table>
*/