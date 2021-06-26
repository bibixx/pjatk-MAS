import { useUserData } from "../../components/UserContext/UserContext";

import { Form, Input, Button } from 'antd';
import { UserOutlined, LockOutlined } from '@ant-design/icons';
import { Container } from "./Login.styled";
import { useForm } from "antd/lib/form/Form";

export const Login = () => {
  const [form] = useForm();
  const { logIn } = useUserData();

  const onFinish = async ({ username }: { username: string }) => {
    try {
      await logIn(username);
    } catch (error) {
      form.setFields([
        {
          name: 'password',
          errors: ['Nazwa użytkownika lub hasło są błędne.'],
        },
      ]);
    }
  }

  return (
    <Container>
      <Form
        name="normal_login"
        className="login-form"
        onFinish={onFinish}
        form={form}
      >
        <Form.Item
          name="username"
          rules={[{ required: true, message: 'Proszę podać nazwę użytkownika!' }]}
        >
          <Input prefix={<UserOutlined className="site-form-item-icon" />} placeholder="Nazwa użytkownika" />
        </Form.Item>
        <Form.Item
          name="password"
          rules={[{ required: true, message: 'Proszę podać hasło!' }]}
        >
          <Input.Password
            prefix={<LockOutlined className="site-form-item-icon" />}
            type="password"
            placeholder="Hasło"
          />
        </Form.Item>
        <Form.Item>
          <Button type="primary" htmlType="submit" className="login-form-button">
            Zaloguj się
          </Button>
        </Form.Item>
      </Form>
    </Container>
  );
}
