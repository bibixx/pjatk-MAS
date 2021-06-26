import { Layout, Menu } from 'antd';
import { Link } from 'react-router-dom';
import { useUserData } from '../UserContext/UserContext';

const { Header, Content } = Layout;

export const PageLayout: React.FC = ({ children }) => {
  const { logOut, data } = useUserData()

  return (
    <Layout className="layout" style={{ height: '100%' }}>
      <Header>
        <Menu theme="dark" mode="horizontal" selectedKeys={['1']}>
          {data !== null && (
            <>
              <Menu.Item key={1}>
                <Link to="/">Strona główna</Link>
              </Menu.Item>
              <Menu.Item key={2} onClick={() => logOut()}>Wyloguj się</Menu.Item>
            </>
          )}
        </Menu>
      </Header>
      <Content style={{ padding: '0 50px', flex: 1 }}>
        {children}
      </Content>
    </Layout>
  );
}
