<?php

use Illuminate\Support\Facades\Route;


Route::get('/', function () {
    return view('welcome');
});

Route::get('/student/app', function () {
    return view('layouts.app');
});


/*Route::get('/student/create',[\App\Http\Controllers\StudentController::class,'create']);
Route::post('/student/store',[\App\Http\Controllers\StudentController::class,'store'])->name('student-store');
Route::get('/student/index',[\App\Http\Controllers\StudentController::class,'index'])->name('student-index');
Route::get('/student/edit/{id}',[\App\Http\Controllers\StudentController::class,'edit'])->name('student-edit');
Route::post('/student/update/{id}',[\App\Http\Controllers\StudentController::class,'update'])->name('student-update');
Route::get('/student/destroy/{id}',[\App\Http\Controllers\StudentController::class,'destroy'])->name('student-destroy');*/
Route::resource('student', \App\Http\Controllers\StudentController::class);
//------------------------------------------Курсы Курсы Курсы------------------------------------------------------------------------
Route::get('/course/create', [\App\Http\Controllers\CourseController::class, 'create'])->name('course-create');
Route::get('/course/index', [\App\Http\Controllers\CourseController::class, 'index'])->name('course-index');
Route::post('/course/store', [\App\Http\Controllers\CourseController::class, 'store'])->name('course-store');
Route::get('/course/edit/{id}', [\App\Http\Controllers\CourseController::class, 'edit'])->name('course-edit');
Route::post('/course/update/{id}', [\App\Http\Controllers\CourseController::class, 'update'])->name('course-update');
Route::get('/course/destroy/{id}', [\App\Http\Controllers\CourseController::class, 'destroy'])->name('course-destroy');
//------------------------------------------Курсы Курсы Курсы------------------------------------------------------------------------

//------------------------------------------Группы Группы Группы------------------------------------------------------------------------
Route::get('/group/create', [\App\Http\Controllers\GroupController::class, 'create'])->name('group-create');
Route::get('/group/index', [\App\Http\Controllers\GroupController::class, 'index'])->name('group-index');
Route::post('/group/store', [\App\Http\Controllers\GroupController::class, 'store'])->name('group-store');
Route::get('/group/edit/{id}', [\App\Http\Controllers\GroupController::class, 'edit'])->name('group-edit');
Route::post('/group/update/{id}', [\App\Http\Controllers\GroupController::class, 'update'])->name('group-update');
Route::get('/group/destroy/{id}', [\App\Http\Controllers\GroupController::class, 'destroy'])->name('group-destroy');
//------------------------------------------Группы Группы Группы------------------------------------------------------------------------

Auth::routes();

Route::get('/home', [App\Http\Controllers\HomeController::class, 'index'])->name('home');

