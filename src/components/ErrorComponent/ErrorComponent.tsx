interface Props {
  error: Error
}

export const ErrorComponent = ({ error }: Props) => {
  return (
    <pre>
      {JSON.stringify(error, null, 2)}
    </pre>
  );
}
