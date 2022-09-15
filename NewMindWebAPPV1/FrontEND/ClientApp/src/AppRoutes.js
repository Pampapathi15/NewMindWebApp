import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import { Student } from "./components/Student";
import { AddStudent } from "./components/AddStudent"

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
    },
   {
       path: '/student-data',
       element: <Student />
    },
    {
        path: '/AddStudent-data',
        element: <AddStudent/>
    }


];

export default AppRoutes;
