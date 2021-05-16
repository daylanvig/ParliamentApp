

import {
  BrowserRouter as Router,
  Link,
  Switch,
  Route,
  useRouteMatch,
} from 'react-router-dom';
// Pages
import ComparePage from 'pages/ComparePage';
import HomePage from 'pages/HomePage';
import MemberProfilePage from 'pages/MemberProfilePage';

function CustomNavLink({ to, label, activeOnlyWhenExact }: { to: string; label: string, activeOnlyWhenExact: boolean; }) {
  const match = useRouteMatch({
    path: to,
    exact: activeOnlyWhenExact
  });
  return (
    <li className={`navbar-item ${match ? 'is-active' : ''}`}>
      <Link to={to}>{label}</Link>
    </li>
  );
}

function App() {
  return (
    <div className="App">
      <Router>
        <div>
          <nav className='navbar' role='navigation'>
            <ul className='navbar-start'>
              <CustomNavLink to="/" activeOnlyWhenExact={true} label="Home"></CustomNavLink>
              <CustomNavLink to="/Compare" activeOnlyWhenExact={false} label="Compare Votes"></CustomNavLink>
              <CustomNavLink to="/MemberProfile" activeOnlyWhenExact={false} label="Member Profiles"></CustomNavLink>
            </ul>
          </nav>
        </div>
        <Switch>
          <Route path="/Compare">
            <ComparePage></ComparePage>
          </Route>
          <Route path="/MemberProfile/">
            <MemberProfilePage></MemberProfilePage>
          </Route>
          <Route path="/">
            <HomePage></HomePage>
          </Route>
        </Switch>
      </Router>
    </div>
  );
}

export default App;
