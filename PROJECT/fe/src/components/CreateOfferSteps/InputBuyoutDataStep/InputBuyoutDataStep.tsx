import { Button, Form, Input, Typography } from "antd";
import { Box } from "rebass";

const { Title } = Typography;

interface Props {
  onConfirm: (price: number) => void
}

export const InputBuyoutDataStep = ({ onConfirm }: Props) => {
  const onFinish = ({ price } : { price: number }) => {
    onConfirm(+price);
  }

  return (
    <Box mt="2rem">
      <Title>Ile chcesz zaproponować za tę grę?</Title>
      <Form
        name="price_pick"
        onFinish={onFinish}
      >
        <Form.Item
          name="price"
          rules={[{ required: true, message: 'Proszę wprowadzić cenę' }]}
        >
          <Input type="number" suffix="PLN" min="0" />
        </Form.Item>
        <Form.Item>
          <Button type="primary" size="large" htmlType="submit">Dalej</Button>
        </Form.Item>
      </Form>
    </Box>
  );
}
