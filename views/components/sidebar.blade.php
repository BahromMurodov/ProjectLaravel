<div class="sidebar">
    <!--
      Tip 1: You can change the color of the sidebar using: data-color="blue | green | orange | red"
  -->
    <div class="sidebar-wrapper">
        <div class="logo">
            <a href="javascript:void(0)" class="simple-text logo-mini">
                CT
            </a>
            <a href="javascript:void(0)" class="simple-text logo-normal">
                IT-RUN DEVELOPERS
            </a>
        </div>
        <ul class="nav">
            <li class="@if(request()->routeIs('course.*'))active @endif ">
                <a href="{{route('course-index')}}">
                    <i class="tim-icons icon-chart-pie-36"></i>
                    <p>Курсы</p>
                </a>
            </li>
            <li>
                <a href="./icons.html">
                    <i class="tim-icons icon-atom"></i>
                    <p>Журнал</p>
                </a>
            </li>
            <li>
                <a href="./map.html">
                    <i class="tim-icons icon-pin"></i>
                    <p>Пользователи</p>
                </a>
            </li>
            <li>
                <a href="./notifications.html">
                    <i class="tim-icons icon-bell-55"></i>
                    <p>Филиалы</p>
                </a>
            </li>
            <li class="@if(request()->routeIs('group.*'))active @endif ">
                <a href="{{route('group-index')}}">
                    <i class="tim-icons icon-single-02"></i>
                    <p>Группы</p>
                </a>
            </li>
            <li class="@if(request()->routeIs('student.*'))active @endif ">
                <a href="{{route('student.index')}}">
                    <i class="tim-icons icon-puzzle-10"></i>
                    <p>Студенты</p>
                </a>
            </li>
            <li>
                <a href="./typography.html">
                    <i class="tim-icons icon-align-center"></i>
                    <p>Преподователи</p>
                </a>
            </li>
            <li>
                <a
                    href="{{ route('logout') }}"
                    onclick="event.preventDefault();
                                                     document.getElementById('logout-form').submit();">
                    <i class="tim-icons icon-minimal-left"></i>
                    {{ __('Logout') }}

                </a>

                <form id="logout-form" action="{{ route('logout') }}" method="POST" class="d-none">
                    @csrf
                </form>
            </li>
            {{--                <li>--}}
            {{--                    <a href="./rtl.html">--}}
            {{--                        <i class="tim-icons icon-world"></i>--}}
            {{--                        <p>Журнал</p>--}}
            {{--                    </a>--}}
            {{--                </li>--}}
            <li class="active-pro">
                <a href="./upgrade.html">
                    <i class="tim-icons icon-spaceship"></i>
                    <p>Upgrade to PRO</p>
                </a>
            </li>
        </ul>
    </div>
</div>
