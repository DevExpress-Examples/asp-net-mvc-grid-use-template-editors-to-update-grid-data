﻿@Code
    ViewBag.Title = "How to perform GridView instant updating using different editors in the DataItem template "
End Code
<h2>@ViewBag.Message</h2>
<div style="width: 400px">
    @Html.Action("GridViewPartial")
    <div class="status">
        AJAX status
    </div>
</div>
