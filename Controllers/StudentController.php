<?php

namespace App\Http\Controllers;

use App\Http\Requests\StudentRequest;
use App\Models\Students;
use Illuminate\Contracts\Foundation\Application;
use Illuminate\Contracts\View\Factory;
use Illuminate\Contracts\View\View;
use Illuminate\Http\RedirectResponse;
use Illuminate\Http\Request;
use Illuminate\Http\Response;
use Illuminate\Routing\Redirector;

class StudentController extends Controller
{
    /**
     * Display a listing of the resource.
     *
     * @return Application|Factory|View|Response
     */
    public function index()
    {
        $student = Students::all();
        return view('student.index', compact('student'));
    }

    /**
     * Show the form for creating a new resource.
     *
     * @return Application|Factory|View|Response
     */
    public function create()
    {
        return view('student.create');
    }

    /**
     * Store a newly created resource in storage.
     *
     * @param Request $request
     * @return Application|RedirectResponse|Response|Redirector
     */
    public function store(StudentRequest $request)
    {
        Students::create($request->validated());
        return redirect()->route('student.index')->with('success', 'Данные успешно добавлены');
    }

    /**
     * Display the specified $vallidated = $request->validate([
     * 'firstname'=>'required',
     * 'lastname'=>'required',
     * 'date_birth'=>'required',
     * 'email'=>'required',
     * 'phone_number'=>'required',
     * 'city_address'=>'required',
     * 'address'=>'required',
     * 'categoryId'=>''
     * ]);
     * $student = new Students();
     * $student->firstname=$vallidated['firstname'];
     * $student->lastname=$vallidated['lastname'];
     * $student->email=$vallidated['email'];
     * $student->date_birth=$vallidated['date_birth'];
     * $student->phone_number=$vallidated['phone_number'];
     * $student->city_address=$vallidated['city_address'];
     * $student->address=$vallidated['address'];
     *
     * $student->save();
     * return redirect('student/index')->with('success', 'Данные успешно добавлены');resource.
     *
     * @param Students $student
     * @return Response
     */
    public function show(int $id)
    {
        $student = Students::findOrFail($id);
        return view('student.show', $student);
    }

    /**
     * Show the form for editing the specified resource.
     *
     * @param Students $student
     * @return Response
     */
    public function edit($id)
    {

        $student = Students::find($id);
        return view('student.edit', compact('student'));
    }

    /**
     * Update the specified resource in storage.
     *
     * @param StudentRequest $request
     * @param $id
     * @return Application|RedirectResponse|Response|Redirector
     */
    public function update(StudentRequest $request, $id)
    {
        Students::where(['id' => $id])->update($request->validated());
        return redirect()->route('student.index')->with('success', 'Данные успешно обновлены');
    }

    /**
     * Remove the specified resource from storage.
     *
     * @param int $id
     * @return RedirectResponse
     */
    public function destroy(int $id): RedirectResponse
    {
        Students::where('id', $id)->delete();
        return redirect()->route('student.index')->with('success', 'Данные успешно удалены');
    }
}
