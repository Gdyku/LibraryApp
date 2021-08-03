$(document).ready(function () {
  loadData();
});

function loadData() {
  $.ajax({
    url: "api/books/getbooks",
    method: "GET",
    contentType: "application/json;charset=utf-8",
    dataType: "json",
    success: function (result) {
      var html = "";
      $.each(result, function (item) {
        html += "<tr";
        html += "td" + item.Title + "</td>";
        html += "td" + item.Author + "</td>";
        html += "td" + item.Category + "</td>";
        html += "td" + item.ReleaseDate + "</td>";
        html += "td";
      });
      $(".tbody").html(html);
    },
    error: function (errorMessage) {
      alert(errorMessage.responsetext);
    },
  });
}

function Add() {
  var res = validate();
  if (res == false) {
    return false;
  }
  var book = {
    bookID: $("#bookID").val(),
    Title: $("#title").val(),
    Author: $("#author").val(),
    Category: $("#category").val(),
    ReleaseDate: $("#releaseDate").val(),
  };
  $.ajax({
    url: "api/books/createbook",
    data: JSON.stringify(book),
    method: "POST",
    contentType: "application/json;charset=utf-8",
    dataType: "json",
    success: function () {
      loadData();
    },
    error: function (errorMessage) {
      alert(errorMessage.responsetext);
    },
  });
}

function getById(bookId) {
  $("#bookId");
  $("#Title");
  $("#Author");
  $("#Category");
  $("#ReleaseDate");
  $.ajax({
    url: "api/book/getbook/" + bookId,
    method: "GET",
    contentType: "application/json;charset=utf-8",
    dataType: "json",
    success: function (result) {
      $("#bookId").val(result.bookID);
      $("#Title").val(result.Title);
      $("#Author").val(result.Author);
      $("#Category").val(result.Category);
      $("#ReleaseDate").val(result.ReleaseDate);
    },
    error: function (errorMessage) {
      alert(errorMessage.responsetext);
    },
  });
}

function Update() {
  var res = validate();
  if (res == false) {
    return false;
  }
  var book = {
    bookID: $("#bookID").val(),
    Title: $("#title").val(),
    Author: $("#author").val(),
    Category: $("#category").val(),
    ReleaseDate: $("#releaseDate").val(),
  };
  $.ajax({
    url: "api/book/editbook",
    data: JSON.stringify(book),
    method: "PUT",
    contentType: "application/json;charset=utf-8",
    dataType: "json",
    success: function () {
      loadData();
      $("bookId").val("");
      $("#title").val();
      $("#author").val();
      $("#category").val();
      $("#releaseDate").val();
    },
    error: function (errorMessage) {
      alert(errorMessage.responsetext);
    },
  });
}

function Delete(Id) {
  var ans = confirm("Are you sure you want to delete this record?");
  if (ans) {
    $.ajax({
      url: "api/book/deletebook" + Id,
      method: "DELETE",
      success: function () {
        loadData();
      },
      error: function (errorMessage) {
        alert(errorMessage.responsetext);
      },
    });
  }
}
