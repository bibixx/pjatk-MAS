import styled from "@emotion/styled";

export const Container = styled.div`
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(15rem, 1fr));
  grid-gap: 4rem;
  padding: 2rem 0;
`;

export const Image = styled.img`
  aspect-ratio: 1 / 1;
  object-fit: cover;
`;
